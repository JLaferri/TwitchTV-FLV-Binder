using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FLV_Binder_GUI
{
    public partial class TwitchDLDialog : Form
    {
        //Define important tokens in JSON file (required for proper downloading)
        const string URL_TOKEN = "video_file_url";
        const string SIZE_TOKEN = "file_size";

        Main mainForm;

        VideoInfoElement[] videoDisplayInfo = new VideoInfoElement[] {
            new VideoInfoElement("title", "Name"),
            new VideoInfoElement("length", "Length", n => TimeSpan.FromSeconds(Double.Parse(n)).ToString()),
            new VideoInfoElement(SIZE_TOKEN, "Size (MB)", n => (Double.Parse(n)/1000000).ToString()),
            new VideoInfoElement("created_on", "Created"),
            //new VideoInfoElement("kind", "Type"),
            new VideoInfoElement(URL_TOKEN, "URL")
        };
            
        public TwitchDLDialog(Main mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            foreach (VideoInfoElement vie in videoDisplayInfo)
                dataGridViewVideos.Columns.Add(vie.TokenName, vie.DescriptiveName);
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxTargetFolder.Text = fbd.SelectedPath;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOpenChannel_Click(object sender, EventArgs e)
        {
            string uri;
            Stream result;

            uri = "http://api.justin.tv/api/channel/archives/" + textBoxChannel.Text + ".json?limit=100";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            try
            {
                //result = httpWebRequest.GetResponse().ToString();
                WebResponse resp = httpWebRequest.GetResponse();
                result = resp.GetResponseStream();
            }
            catch (Exception)
            {
                Debug.WriteLine("lul");
                return;
            }


            JArray twitchResult = JArray.Load(new JsonTextReader(new StreamReader(result)));
            //IEnumerable<JObject> test = (IEnumerable<JObject>)twitchResult.Values<JObject>().Select(n => n.SelectToken("video_file_url"));

            dataGridViewVideos.Rows.Clear();
            
            //Add all results to gridView
            string[] newRow = new string[videoDisplayInfo.Length];
            int i;

            foreach (JToken tok in twitchResult)
            {
                for (i = 0; i < videoDisplayInfo.Length; i++)
                    newRow[i] = videoDisplayInfo[i].ExecuteTransform(tok.SelectToken(videoDisplayInfo[i].TokenName).ToString());

                dataGridViewVideos.Rows.Add(newRow);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (textBoxTargetFolder.Text.Length <= 0)
            {
                MessageBox.Show("Please select a folder to download to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (backgroundWorkerDownloader.IsBusy)
            {
                MessageBox.Show("Please wait until download is complete before starting a new one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            backgroundWorkerDownloader.RunWorkerAsync();
            //dataGridView1.SelectedCells.
        }

        private void backgroundWorkerDownloader_DoWork(object sender, DoWorkEventArgs e)
        {
            int i;
            int totalBytes = 0, currentBytes = 0;
            string[] fileURLs = new string[dataGridViewVideos.SelectedRows.Count];
            int[] fileSizes = new int[dataGridViewVideos.SelectedRows.Count];

            //Pull important information from selected rows into more usable structures
            i = 0;
            foreach (DataGridViewRow row in dataGridViewVideos.SelectedRows)
            {
                fileURLs[i] = row.Cells[URL_TOKEN].Value.ToString();
                fileSizes[i] = (int)(Double.Parse(row.Cells[SIZE_TOKEN].Value.ToString()) * 1000000);
                totalBytes += fileSizes[i];
                i++;
            }

            //Download each file one at a time and report status
            string filePath;
            int indexAfterLastSlash;
            FLVDescriptor[] newFiles = new FLVDescriptor[fileURLs.Length];

            for (i = 0; i < fileURLs.Length; i++)
            {
                indexAfterLastSlash = fileURLs[i].LastIndexOf('/') + 1;
                filePath = textBoxTargetFolder.Text + 
                    (textBoxTargetFolder.Text.EndsWith("\\") ? "" : "\\") +
                    fileURLs[i].Substring(indexAfterLastSlash, fileURLs[i].Length - indexAfterLastSlash);

                newFiles[i] = new FLVDescriptor(filePath, FLVLocation.LocalDisk);

                // use the webclient object to download the file
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    // open the file at the remote URL for reading
                    using (System.IO.Stream streamRemote = client.OpenRead(new Uri(fileURLs[i])))
                    {
                        // using the FileStream object, we can write the downloaded bytes to the file system
                        using (Stream streamLocal = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            // loop the stream and get the file into the byte buffer
                            int iByteSize = 0;
                            byte[] byteBuffer = new byte[fileSizes[i]];
                            while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                            {
                                // write the bytes to the file system at the file path specified
                                streamLocal.Write(byteBuffer, 0, iByteSize);
                                currentBytes += iByteSize;

                                // calculate the progress out of a base "100"
                                double dProgressPercentage = ((double)currentBytes / (double)totalBytes);
                                int iProgressPercentage = (int)(dProgressPercentage * 100);

                                // update the progress bar
                                backgroundWorkerDownloader.ReportProgress(iProgressPercentage);
                            }

                            // clean up the file stream
                            streamLocal.Close();
                        }

                        // close the connection to the remote server
                        streamRemote.Close();
                    }
                }
            }

            e.Result = newFiles;
            //mainForm.AddFLVs(newFiles);
        }

        private void backgroundWorkerDownloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mainForm.AddFLVs((FLVDescriptor[])e.Result);

            //Flash this form and main form to indicate download completion and additions to list
            FlashWindow.Flash(this);
            FlashWindow.Flash(mainForm);
        }

    }
}
