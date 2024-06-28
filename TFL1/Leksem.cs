using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL1
{
    public class Leksem
    {
        public Leksem(string type, string text, int nach, int konets, int strNum)
        {
            this.Type = type;
            this.Text = text;
            this.Start = nach;
            this.End = konets;
            this.StrNum = strNum;
        }
        public string Type;
        public string Text;
        public int Start;
        public int End;
        public int StrNum;
    }
}