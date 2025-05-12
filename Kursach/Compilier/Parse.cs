using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
    public enum ERRORTYPE { DELETE, ADD, CHANGE, NONE, START,ADDEND }
    public class Parse
    {
        public Token GetNeedToken(List<Token> tokencurrent)
        {
            if (tokencurrent.Count != 0)
            {
                if (tokencurrent[tokencurrent.Count - 1] == Token.STRUCT)
                {
                    return Token.ID;
                }
                else if (tokencurrent[tokencurrent.Count - 1] == Token.ID)
                {
                    if (tokencurrent[tokencurrent.Count - 2] == Token.TYPE)
                    {
                        return Token.SEM;
                    }
                    else if (tokencurrent[tokencurrent.Count - 2] == Token.STRUCT)
                    {
                        return Token.OPENBRACE;
                    }
                }
                else if (tokencurrent[tokencurrent.Count - 1] == Token.TYPE)
                {
                    return Token.ID;
                }
                else if (tokencurrent[tokencurrent.Count - 1] == Token.OPENBRACE)
                {
                    return Token.CLOSEBRACE;
                }
                else if (tokencurrent[tokencurrent.Count - 1] == Token.CLOSEBRACE)
                {
                    return Token.SEM;
                }
                else if (tokencurrent[tokencurrent.Count - 1] == Token.SEM)
                {
                    if (tokencurrent[tokencurrent.Count - 2] == Token.CLOSEBRACE)
                    {
                        return Token.STRUCT;
                    }
                    else
                    {
                        return Token.CLOSEBRACE;
                    }

                }
                else
                {
                    return Token.ERROR;
                }
            }
            else
            {
                return Token.STRUCT;
            }
            return Token.ERROR;
        }
        public List<string> Errors = new List<string>();
        public List<Token> tokens = new List<Token>();
        public List<Token> current_tokens = new List<Token>();
        public int Current_Position = 0;
        public Parse(List<Token> tok)
        {
            tokens = tok;
        }
        int absolute = 0;
        public List<MyToken> myTokens = new List<MyToken>();
        private string returnToken(Token token)
        {
            switch (token)
            {
                case Token.CLOSEBRACE:
                    return "}";
                case Token.OPENBRACE:
                    return "{";
                case Token.SEM:
                    return ";";
                case Token.STRUCT:
                    return "struct";
                case Token.ID:
                    return "ID";
                case Token.END:
                    return ";";
                case Token.TYPE:
                    return "TYPE";

            }
            return "id";
        }
        public int Parser(ERRORTYPE error, int current_token, ref TokenReturn token, int errorCount = 0, int errorx = 0)
        {
            if (myTokens.Count != 0)
            {
                if (error == ERRORTYPE.DELETE)
                {
                    token.error.Add(new MyToken($"Ожидается  {myTokens[current_token].Value} \"{myTokens[current_token].Value}\"", myTokens[current_token].Position, myTokens[current_token].Line));
                    current_token++;
                    errorCount++;
                }
                else if (error == ERRORTYPE.CHANGE)
                {
                    token.error.Add(new MyToken($"Ожидается \"{returnToken(GetNeedToken(token.tokens))}\",было  получено \"{myTokens[current_token].Value}\"", myTokens[current_token].Position, myTokens[current_token].Line));
                    token.tokens.Add(GetNeedToken(token.tokens));
                    current_token++;
                    errorCount++;
                }
                else if (error == ERRORTYPE.ADD)
                {
                    token.error.Add(new MyToken($"Ожидается \"{returnToken(GetNeedToken(token.tokens))}\"", myTokens[current_token].Position, myTokens[current_token].Line));
                    token.tokens.Add(GetNeedToken(token.tokens));
                    errorCount++;
                }
                else if (error == ERRORTYPE.ADDEND)
                {
                    token.error.Add(new MyToken($"Ожидается \"{returnToken(GetNeedToken(token.tokens))}\"", myTokens[myTokens.Count - 1].Position + 3, myTokens[myTokens.Count - 1].Line));
                    token.tokens.Add(GetNeedToken(token.tokens));
                    errorCount++;
                }
                else if (error == ERRORTYPE.NONE)
                {
                    token.tokens.Add(tokens[current_token]);
                    current_token++;
                }

                if (tokens.Count > current_token)
                {
                    if (GetNeedToken(token.tokens) != tokens[current_token])
                    {
                        if ((GetNeedToken(token.tokens) == Token.CLOSEBRACE && tokens[current_token] == Token.TYPE) ||
                            ((GetNeedToken(token.tokens) == Token.SEM && tokens[current_token] == Token.TYPE)))
                        {
                            return Parser(ERRORTYPE.NONE, current_token, ref token, errorCount);
                        }
                        else
                        {
                            int minErrors = int.MaxValue;

                            var token1 = new TokenReturn(token.tokens, token.error);

                            int errorsDelete = Parser(ERRORTYPE.DELETE, current_token, ref token1, errorCount);
                            if (errorsDelete < minErrors)
                                minErrors = errorsDelete;
                            var token2 = new TokenReturn(token.tokens, token.error);
                            int errorsChange = Parser(ERRORTYPE.CHANGE, current_token, ref token2, errorCount);
                            if (errorsChange <= minErrors)
                            {
                                minErrors = errorsChange;
                                token1 = new TokenReturn(token2.tokens, token2.error);
                            }

                            var token3 = new TokenReturn(token.tokens, token.error);
                            int errorsAdd = Parser(ERRORTYPE.ADD, current_token, ref token3, errorCount);
                            if (errorsAdd <= minErrors)
                            {
                                minErrors = errorsAdd;
                                token1 = new TokenReturn(token3.tokens, token3.error);
                            }
                            token = token1;
                            return minErrors;
                        }
                    }
                    else
                    {
                        return Parser(ERRORTYPE.NONE, current_token, ref token, errorCount);
                    }
                }
                else
                {
                    int ob = 0;
                    int obp = 0;
                    for (int i = 0; i < token.tokens.Count; i++)
                    {
                        if (token.tokens[i] == Token.OPENBRACE)
                        {
                            ob++;
                            obp = 1;
                        }
                        if (token.tokens[i] == Token.CLOSEBRACE)
                        {
                            ob--;
                        }


                    }
                    if (ob > 0 || obp == 0)
                    {
                        var token3 = new TokenReturn(token.tokens, token.error);
                        int errorsAdd = Parser(ERRORTYPE.ADDEND, current_token, ref token3, errorCount);
                        token = token3;
                        return errorsAdd;
                    }
                    if (token.tokens[token.tokens.Count - 1] == Token.CLOSEBRACE)
                    {
                        var token3 = new TokenReturn(token.tokens, token.error);
                        int errorsAdd = Parser(ERRORTYPE.ADDEND, current_token, ref token3, errorCount);
                        token = token3;
                        return errorsAdd;
                    }

                }
                return errorCount;
            }
            return errorCount;
        }

    }
}
