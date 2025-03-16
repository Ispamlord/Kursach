using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach.Compilier
{
    public class Scan1
    {
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
        public Scan1(string text) {
            this.text = text; 
        }
        public List <string> keywords = new List<string>();
        public List<string> keyword = new List<string>();
        public List<int> codes = new List<int>();
        public string start()
        {
            text = Regex.Replace(text, "{", " { ");
            text = Regex.Replace(text, "}", " } ");
            text = Regex.Replace(text, ";", " ; ");
            text.Trim();
            var result = Regex.Matches(text, @"\w+|[{};=,()]|\s+");
            int prevcode = 0;
            foreach (Match match in result) {
                int code =0;
                if (match.Value.Trim().Length == 0)
                {
                    codes.Add(9);
                    keywords.Add("Обязательный пробел");
                    code = 0;
                }
                else if (keyValuePairs.ContainsKey(match.Value))
                {
                    code = keyValuePairs[match.Value];
                    codes.Add(code);
                    if (code>0&&code<9)
                    {

                    }else if (code == 10)
                    {
                        keywords.Add("Ключевое слово");
                    }
                    keyword.Add(match.Value);
                }
                else if (letter(match.Value)) {
                    code = 13;
                    codes.Add(code);
                    keywords.Add("Id");
                    keyword.Add(match.Value);
                }
                else
                {
                   return "error";
                }

                    //if(prevcode >= 1 && prevcode<9)
                    //{

                    //}
                }

                return "error";

            
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
