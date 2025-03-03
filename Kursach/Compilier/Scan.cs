using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
    /*
     <public/private/protected/" ">,
     <int/char/string/bool/float/double/long>
     public struct name{
        public "type" name;
        

     }
     */
   
    public class Scan
    {
        public string str { get; set; }
        public string[] words;
        public Scan(string input)
        {
            str = input;
            GetStringtWords();
        }
        public void scan() {
            int i = 0;
            while (true)
            {
                


                break;
            }
        }
        public void GetStringtWords()
        {
            words = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        }
        //public bool TotalCheck(int i)
        //{
        //    switch (i)
        //    {
        //        case 0:
        //            return CheckFirst(words[i]);
        //        case 1:
                    
        //            break;
        //        case 2:
        //            break;
        //        case 3:
        //            break;
        //        default:
        //            break;
        //    }
        //    return true;
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
        private bool CheckStruct(string word) {
            switch (word)
            {
                case "struct":
                    return true;

                default:
                    letter(word);
                    return false;
            }
        }
        public bool CheckModifd(string word)
        {
            switch (word)
            {
                case "public":
                    return true;
                    
                case "private":
                    return true;
                    
                case "protected":
                    return true;
                    
                case "struct":
                    return true;
                    
                default :
                    return false;
            }
        }
    }
}
