using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL1
{
    public class Regular
    {
        public Regular(string text, int nach, int konets, int strNum)
        {
            this.Text = text;
            this.Start = nach;
            this.End = konets;
            this.StrNum = strNum;
        }

        public string Text;
        public int Start;
        public int End;
        public int StrNum;
    }
}
