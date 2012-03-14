using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Diagnostics;

namespace FLV_Binder_GUI
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();

            string swffile;

            //Show file names in listBox instead of full paths
            listBoxVideos.DisplayMember = "FLVName";

            //Load JWPlayer swf
            axShockwaveFlashPreview.FlashVars = "autostart=true";
            axShockwaveFlashPreview.ScaleMode = 0;
            //axShockwaveFlash1.Quality2 = "High";
            swffile = EmbeddedResourceTools.ExtractResource("JWPlayer.player.swf");
            axShockwaveFlashPreview.LoadMovie(0, swffile);
            axShockwaveFlashPreview.Play();

            //Deletes temp swf file created by ExtractResource
            System.IO.File.Delete(swffile);
        }

        public void AddFLVs(FLVDescriptor[] flvs)
        {
            listBoxVideos.Items.AddRange(flvs);
        }

        private void buttonFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Multiselect = true;

            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Create FLVDescriptors from all selected files and add them to listBoxx
                FLVDescriptor[] flvs = (from s in diag.FileNames select new FLVDescriptor(s, FLVLocation.LocalDisk)).ToArray<FLVDescriptor>();
                //flvs = diag.FileNames.Select<string, FLVDescriptor>(s => new FLVDescriptor(s, FLVLocation.LocalDisk)).ToArray<FLVDescriptor>();
                AddFLVs(flvs);
            }
        }

        private void buttonBind_Click(object sender, EventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Flash Video|*.flv";
            diag.Title = "Save a Flash Video";

            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "flvbind";
                proc.StartInfo.Arguments = diag.FileName + " " + String.Join(" ", listBoxVideos.Items.Cast<FLVDescriptor>().Select(n => n.FLVFullPath).ToArray<String>());

                proc.Start();
            }
        }

        private void listBoxVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxVideos.SelectedIndex >= 0 && listBoxVideos.SelectedItems.Count <= 1)
            {
                axShockwaveFlashPreview.CallFunction("<invoke name=\"sendEvent\" returntype=\"xml\">" +
                    "<arguments><string>load</string><string>" +
                    ((FLVDescriptor)listBoxVideos.SelectedItem).FLVFullPath +
                    "</string></arguments></invoke>");
            }
        }

        private void buttonFromTwitch_Click(object sender, EventArgs e)
        {
            TwitchDLDialog tdld = new TwitchDLDialog(this);

            tdld.Show();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Remove all selected videos from list
            while (listBoxVideos.SelectedIndices.Count > 0)
                listBoxVideos.Items.RemoveAt(listBoxVideos.SelectedIndices[0]);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            //Do nothing if more than one video selected or if selected item already at index 0
            if (listBoxVideos.SelectedIndices.Count > 1 ||
                listBoxVideos.SelectedIndex == 0) 
                return;

            int idx = listBoxVideos.SelectedIndex;

            //Store copy of data in selected index
            object temp = listBoxVideos.Items[idx];

            //Remove at current location
            listBoxVideos.Items.RemoveAt(idx);

            //Recreate at location - 1, reselect
            listBoxVideos.Items.Insert(idx - 1, temp);
            listBoxVideos.SelectedIndex = idx - 1;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            //Do nothing if more than one video selected or if selected item already at last index
            if (listBoxVideos.SelectedIndices.Count > 1 ||
                listBoxVideos.SelectedIndex == (listBoxVideos.Items.Count - 1))
                return;

            int idx = listBoxVideos.SelectedIndex;

            //Store copy of data in selected index
            object temp = listBoxVideos.Items[idx];

            //Remove at current location
            listBoxVideos.Items.RemoveAt(idx);

            //Recreate at location + 1, reselect
            listBoxVideos.Items.Insert(idx + 1, temp);
            listBoxVideos.SelectedIndex = idx + 1;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            List<object> tempList = new List<object>();

            tempList.AddRange(listBoxVideos.Items.Cast<object>());

            listBoxVideos.Items.Clear();

            Random rnd = new Random();
            int num;
            while (tempList.Count > 0)
            {
                num = rnd.Next(0, tempList.Count);

                listBoxVideos.Items.Add(tempList[num]);
                tempList.RemoveAt(num);
            }
        }

    }
}
