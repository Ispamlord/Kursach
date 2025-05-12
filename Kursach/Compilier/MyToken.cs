using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
    public class MyToken
    {
        public string Value { get; set; }
        public int Line { get; set; }
        public int Position { get; set; }
        public string mess { get; set; }
        public MyToken(int pos, int lin, string val)
        {
            Value = val;
            Line = lin;
            Position = pos;
        }
        public MyToken(string mess, int pos, int lin)
        {
            Line = lin;
            Position = pos;
            this.mess = mess;
        }
    }
}
