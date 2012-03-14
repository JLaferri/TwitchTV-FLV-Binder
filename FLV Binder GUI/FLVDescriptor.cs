using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLV_Binder_GUI
{
    public enum FLVLocation 
    {
        TwitchTV,
        LocalDisk
    }

    public class FLVDescriptor
    {
        private String flvName;
        private String flvPath;
        private String flvFullPath;

        public String FLVName { get { return flvName; } set { flvName = value; } }
        public String FLVPath { get { return flvPath; } set { flvPath = value; } }
        public String FLVFullPath { get { return flvFullPath; } set { flvFullPath = value; } }

        public FLVDescriptor(String url, FLVLocation loc)
        {
            int pos;

            switch (loc)
            {
                case FLVLocation.LocalDisk:
                    pos = url.LastIndexOf("\\") + 1;
                    flvName = url.Substring(pos, url.Length - pos);
                    flvPath = url.Substring(0, pos);
                    flvFullPath = url;
                    break;
                case FLVLocation.TwitchTV:
                    break;
            }
        }
    }
}
