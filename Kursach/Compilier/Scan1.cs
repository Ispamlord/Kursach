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
        public Scan1(string text) {
            this.text = text; 
        }
        public string start()
        {
            
            while (true) {
                text = Regex.Replace(text, "{", " { ");
                text = Regex.Replace(text, "}", " } ");
                text = Regex.Replace(text, ";", " ; ");
                string result = Regex.Replace(text, @"\s+", " ").Trim();
                string[] sstruct = result.Split(new char[] { ' ' });
                int[] code = new int[result.Length];
                for (int i = 0; i < sstruct.Length; i++) {

                    switch (sstruct[i]) {
                        case "struct":
                            code[i] = 1;
                            break;
                        case "int":
                            code[i] = 2;
                            break;
                        case "string":
                            code[i] = 3;
                            break;
                        case "double":
                            code[i] = 4;
                            break;
                        case "float":
                            code[i] = 5;
                            break;
                        case "public":
                            code[i] = 6;
                            break;
                        case "private":
                            code[i] = 7;
                            break;
                        case "protected":
                            code[i] = 8;
                            break;
                        case " ":
                            code[i] = 10;
                            break;
                        case "{":
                            code[i] = 11;
                            break;
                        case "}":
                            code[i] = 12;
                            break;
                        case ";":
                            code[i] = 13;
                            break;
                        default:
                            code[i] = 0;
                            break;
                            
                    }
                    if ((code[i-1] == 10 && (code[i-2]>=1 && code[i-2] <= 5)))
                    {
                        code[i] = 9;
                    }
                    if (code[i] == 0)
                    {
                        error += "error";   
                    }
                }
                return error;

                return result;
            }
        }
       

        //public int code(string word)
        //{
        //    switch (word)
        //    {
        //        case "struct": 

        //            break;
        //    }

        //    return 0;
        //}
        private string letter(string word)
        {
            if (char.IsDigit(word[0]))
                return string.Empty;

            if (word.All(c => char.IsLetterOrDigit(c) || c == '_'))
            {
                return word;
            }
            return string.Empty;
        }

    }
}
