using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
  
    public enum Token { START, STRUCT, OPENBRACE, TYPE, ID, SEM, CLOSEBRACE, END, ERROR }
    public enum TokenК
    {
        IF,
        THEN,
        ELSE,
        GOTO,
        OPERATOR,    // >, <, =
        SEMICOLON,   // ;
        ID,          // Идентификатор (например, X)
        NUMBER,      // Число (например, 100)
        UNKNOWN
    }
    public class Scan
    {
        Dictionary<string, Token> state = new Dictionary<string, Token>();
        public string text;
        public string[] words;

        public Dictionary<string, int> keyValuePairs = new Dictionary<string, int>()
        {
            { "IF", 1 },
            { "THEN", 2 },
            { "ELSE", 3 },
            { "GOTO", 4 },
            { ">", 5 },
            { "<", 6 },
            { "=", 7 },
            { ";", 8 },
            { " ", 9 } // пробел
        };

        public List<MyToken> myTokens;
        public List<int> line = new List<int>();
        public List<int> position = new List<int>();
        public Scan(string text)
        {
            this.text = text;
            myTokens = new List<MyToken>();
            line = new List<int>();
            position = new List<int>();
        }
        public List<string> keywords = new List<string>();
        public List<string> keyword = new List<string>();
        public List<int> codes = new List<int>();
        public List<Token> tokens = new List<Token>();
        public List<string> errors = new List<string>();

        public List<string> fortoken = new List<string>();
        public void Tokenize()
        {
            for (int i = 0; i < codes.Count; i++)
            {
                switch (codes[i])
                {
                    case 1:
                        tokens.Add(Token.STRUCT);
                        fortoken.Add(keyword[i]);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        tokens.Add(Token.TYPE);
                        fortoken.Add(keyword[i]);
                        break;
                    case 10:
                        tokens.Add(Token.OPENBRACE);
                        break;
                    case 11:
                        tokens.Add(Token.CLOSEBRACE);
                        fortoken.Add(keyword[i]);
                        break;
                    case 12:
                        tokens.Add(Token.SEM);
                        fortoken.Add(keyword[i]);
                        break;
                    case 13:
                        tokens.Add(Token.ID);
                        fortoken.Add(keyword[i]);
                        break;
                    default:
                        break;
                }
            }
        }
        
        public void Lexic()
        {
            int i = 0;
            int prevcode = 0;
            int line = 1;
            while (i < text.Length)
            {
                char c = text[i];
                if (c == '\n')
                {
                    line++;
                    i++;
                    continue;
                }
                // Пробел
                if (char.IsWhiteSpace(c))
                {
                    if (prevcode != 9 && (prevcode >= 1 && prevcode < 9))
                    {
                        codes.Add(keyValuePairs[" "]);
                        keywords.Add("WhiteSpace");
                        keyword.Add(" ");
                    }
                    i++;
                    continue;
                }

                // Разделители { } ;
                if (IsDelimiter(c.ToString()))
                {
                    int code = keyValuePairs[c.ToString()];
                    codes.Add(code);
                    if (code > 0 && code < 6)
                        keywords.Add("keyword");
                    else if (code == 10 || code == 11)
                        keywords.Add("razdelitel");
                    else if (code == 12)
                        keywords.Add("end operator");
                    myTokens.Add(new MyToken(  i, line, c.ToString()));
                    keyword.Add(c.ToString());
                    prevcode = code;
                    i++;
                    continue;
                }



                // Идентификатор или ключевое слово
                if (char.IsLetter(c) || c == '_')
                {
                    string cleaned = "";
                    int start = i;
                    bool hasRussian = false;

                    while (i < text.Length && !char.IsWhiteSpace(text[i]) && !IsDelimiter(text[i].ToString()))
                    {
                        char ch = text[i];

                        if (char.IsLetterOrDigit(ch) || ch == '_')
                        {
                            // Проверка на русские символы
                            if (ch >= 'А' && ch <= 'я' || ch == 'ё' || ch == 'Ё')
                            {
                                hasRussian = true;
                            }
                            cleaned += ch;
                        }
                        else
                        {
                            errors.Add(ch.ToString()); // символ с ошибкой — в отдельный список
                            this.line.Add(line);
                            this.position.Add(i);
                        }

                        i++;
                    }

                    if (cleaned.Length > 0)
                    {
                        if (hasRussian)
                        {
                            // Русское слово — игнорировать или добавить в ошибки
                            errors.Add(cleaned); // можно закомментировать, если не нужно
                            this.line.Add(line);
                            this.position.Add(i);
                        }
                        else
                        {
                            if (keyValuePairs.ContainsKey(cleaned))
                            {
                                int code = keyValuePairs[cleaned];
                                codes.Add(code);
                                keywords.Add("keyword");
                                keyword.Add(cleaned);
                                myTokens.Add(new MyToken(start, line, cleaned));
                                prevcode = code;
                            }
                            else
                            {
                                codes.Add(13);
                                keywords.Add("Id");
                                keyword.Add(cleaned);
                                myTokens.Add(new MyToken(start, line, cleaned));
                                prevcode = 13;
                            }
                        }
                    }

                    continue;
                }

                // Прочие символы — ошибка
                if (c != '{' && c != '}' && c != ';')
                {
                    errors.Add(c.ToString()); // ошибка только в errors
                    this.line.Add(line);
                    this.position.Add(i);
                }

                i++;
            }
        }


        private bool IsSymbol(char c)
        {
            // Символы, которые могут входить в "грязные" идентификаторы
            return "@$.#%&*!?\"\\|:[]/+-=<>()".Contains(c);
        }

        private bool IsDelimiter(string s)
        {
            return keyValuePairs.ContainsKey(s) &&
                   (s.Length == 1 && "{};".Contains(s));
        }

        private bool letter(string word)
        {
            if (char.IsDigit(word[0]))
                return false;

            if (word.All(c => char.IsLetterOrDigit(c) || c == '_') && !Regex.IsMatch(word, "[А-Яа-я]"))
            {
                return true;
            }
            return false;
        }
    }
}
