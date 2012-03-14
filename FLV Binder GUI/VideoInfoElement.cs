using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FLV_Binder_GUI
{
    public class VideoInfoElement
    {
        private Func<string,string> valueFunction;
        private string tokenName, descriptiveName;

        public string TokenName { get { return tokenName; } set { tokenName = value; } }
        public string DescriptiveName { get { return descriptiveName; } set { descriptiveName = value; } }

        public VideoInfoElement(string tokenName, string descriptiveName, Func<string, string> valueFunction)
        {
            this.tokenName = tokenName;
            this.descriptiveName = descriptiveName;
            this.valueFunction = valueFunction;
        }

        public VideoInfoElement(string tokenName, string descriptiveName) : this(tokenName, descriptiveName, n => n) { }

        public string ExecuteTransform(string rawToken)
        {
            return valueFunction(rawToken);
        }
    }
}
