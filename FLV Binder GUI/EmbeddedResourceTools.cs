using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FLV_Binder_GUI
{
    class EmbeddedResourceTools
    {
        public static string ExtractResource(string resourceName)
        {
            //look for the resource name
            foreach (string currentResource in
            System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (currentResource.LastIndexOf(resourceName) != -1)
                {
                    //create temporary file whose name to hijack
                    string fqnTempFile = System.IO.Path.GetTempFileName();
                    string path = System.IO.Path.GetDirectoryName(fqnTempFile);
                    string rootName = System.IO.Path.GetFileNameWithoutExtension(fqnTempFile);
                    string destFile = path + @"\" + rootName + "." +
                    System.IO.Path.GetExtension(currentResource);

                    //Get byte information or resource and write into buffer
                    System.IO.Stream fs =
                        System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(currentResource);

                    byte[] buff = new byte[fs.Length];
                    fs.Read(buff, 0, (int)fs.Length);
                    fs.Close();

                    //Write buffer into file
                    System.IO.FileStream destStream = new System.IO.FileStream(destFile, FileMode.Create);
                    destStream.Write(buff, 0, buff.Length);
                    destStream.Close();

                    //Delete .tmp file
                    System.IO.File.Delete(fqnTempFile);

                    return destFile;
                }
            }

            throw new Exception("Resource not found : " + resourceName);
        }
    }
}
