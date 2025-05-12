using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
    public class TokenReturn
    {
        public List<Token> tokens { get; set; } = new List<Token>();
        public List<MyToken> error { get; set; } = new List<MyToken>();

        public TokenReturn() { }

        public TokenReturn(List<Token> tokens, List<MyToken> error)
        {
            this.tokens = new List<Token>(tokens);
            this.error = new List<MyToken>(error);
        }
    }
}
