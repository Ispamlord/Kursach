using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
    enum Token { START, StructKeyword, OpenBrace, StructName, Mod, Type, IDentificator, Semicolon, CloseBrace, END, error }
    public class Scan
    {
        Dictionary<string, Token> state = new Dictionary<string, Token>();
        public string text;
        public string[] words;
        public string error = "";
        public Dictionary<string, int> keyValuePairs = new Dictionary<string, int>()
        {
            { "struct", 1 },
            { "int", 2},
            { "string", 3},
            { "double", 4},
            { "float", 5},
            { "public", 6},
            { "private", 7},
            { "protected", 8},
            { " ", 9},
            { "{", 10},
            { "}", 11},
            { ";", 12}
        };
        public Scan(string text)
        {
            this.text = text;
        }
        public List<string> keywords = new List<string>();
        public List<string> keyword = new List<string>();
        public List<int> codes = new List<int>();
        public void Lexic()
        {
            var result = Regex.Matches(text, @"\w+|[{};/\+-?@\""=,()]|\s+|\"".*?\""");
            int prevcode = 0;
            foreach (Match match in result)
            {
                int code = 0;
                if (match.Value.Trim().Length == 0 && prevcode != 9 && (prevcode >= 1 && prevcode < 9))
                {
                    code = keyValuePairs[match.Value];
                    codes.Add(code);
                    keywords.Add("WhiteSpace");
                    keyword.Add(match.Value);
                }
                else if (keyValuePairs.ContainsKey(match.Value))
                {
                    code = keyValuePairs[match.Value];
                    if (code != 9)
                    {
                        codes.Add(code);
                        if (code > 0 && code < 9)
                        {
                            keywords.Add("keyword");
                        }
                        else if (code == 10 || code == 11)
                        {
                            keywords.Add("razdelitel");
                        }
                        else if (code == 12)
                        {
                            keywords.Add("end operator");
                        }
                        keyword.Add(match.Value);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (letter(match.Value))
                {
                    code = 13;
                    codes.Add(code);
                    keywords.Add("Id");
                    keyword.Add(match.Value);
                }
                else
                {
                    if (match.Value.Trim().Length != 0)
                    {
                        code = 0;
                        codes.Add(code);
                        keywords.Add("Error");
                        keyword.Add(match.Value);
                    }
                }
                prevcode = code;
            }
        }

        public void Syntax()
        {

        }


        private bool letter(string word)
        {
            if (char.IsDigit(word[0]))
                return false;

            if (word.All(c => char.IsLetterOrDigit(c) || c == '_'))
            {
                return true;
            }
            return false;
        }
    }
}
