using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
    public enum TokenType2
    {
        PLUS, MINUS, MUL, DIV,
        LPAREN, RPAREN,
        DOT,
        NUMBER,
        FUNCTION,
        EOF,
        INVALID
    }

    public class Token2
    {
        public TokenType2 Type;
        public string Value;

        public Token2(TokenType2 type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"{Type}: {Value}";
    }
    public class Lexer2
    {
        private string input;
        private int pos;
        private char Current => pos < input.Length ? input[pos] : '\0';

        private static readonly string[] Functions = { "sin", "cos", "tg", "ctg", "log", "ln" };

        public Lexer2(string input)
        {
            this.input = input;
            pos = 0;
        }

        private void Advance() => pos++;

        public Token2 GetNextToken()
        {
            while (char.IsWhiteSpace(Current)) Advance();

            if (char.IsDigit(Current))
            {
                return new Token2(TokenType2.NUMBER, ReadNumber());
            }

            if (char.IsLetter(Current))
            {
                string word = ReadWord();
                if (Functions.Contains(word))
                {
                    return new Token2(TokenType2.FUNCTION, word);
                }
                return new Token2(TokenType2.INVALID, word);
            }

            switch (Current)
            {
                case '+': Advance(); return new Token2(TokenType2.PLUS, "+");
                case '-': Advance(); return new Token2(TokenType2.MINUS, "-");
                case '*': Advance(); return new Token2(TokenType2.MUL, "*");
                case '/': Advance(); return new Token2(TokenType2.DIV, "/");
                case '(': Advance(); return new Token2(TokenType2.LPAREN, "(");
                case ')': Advance(); return new Token2(TokenType2.RPAREN, ")");
                case '.': Advance(); return new Token2(TokenType2.DOT, ".");
                case '\0': return new Token2(TokenType2.EOF, "");
                default:
                    Advance();
                    return new Token2(TokenType2.INVALID, Current.ToString());
            }
        }

        private string ReadNumber()
        {
            var sb = new StringBuilder();
            while (char.IsDigit(Current))
            {
                sb.Append(Current);
                Advance();
            }
            return sb.ToString();
        }

        private string ReadWord()
        {
            var sb = new StringBuilder();
            while (char.IsLetter(Current))
            {
                sb.Append(Current);
                Advance();
            }
            return sb.ToString();
        }
    }

    public class Parser2
    {
        private Lexer2 lexer;
        private Token2 currentToken;

        public Parser2(Lexer2 lexer)
        {
            this.lexer = lexer;
            currentToken = lexer.GetNextToken();
        }

        private void Eat(TokenType2 type, List<string> trace)
        {
            if (currentToken.Type == type)
            {
                currentToken = lexer.GetNextToken();
            }
            else
            {
                trace.Add($"[Ошибка: ожидалось {type}, найдено {currentToken.Type}]");
                currentToken = lexer.GetNextToken(); // Простое восстановление
            }
        }

        public List<string> ParseExpression() => Expression();
        public List<string> ParseTerm() => Term();
        public List<string> ParseFactor() => Factor();
        public List<string> ParseNumber() => Number();
        public List<string> ParseFunction() => Function();

        private List<string> Expression()
        {
            var trace = new List<string> { "Вызов <Выражение>" };
            trace.AddRange(Term());
            while (currentToken.Type == TokenType2.PLUS || currentToken.Type == TokenType2.MINUS)
            {
                Eat(currentToken.Type, trace);
                trace.AddRange(Term());
            }
            return trace;
        }

        private List<string> Term()
        {
            var trace = new List<string> { "Вызов <Слагаемое>" };
            trace.AddRange(Factor());
            while (currentToken.Type == TokenType2.MUL || currentToken.Type == TokenType2.DIV)
            {
                Eat(currentToken.Type, trace);
                trace.AddRange(Factor());
            }
            return trace;
        }

        private List<string> Factor()
        {
            var trace = new List<string> { "Вызов <Множитель>" };
            if (currentToken.Type == TokenType2.PLUS || currentToken.Type == TokenType2.MINUS)
            {
                Eat(currentToken.Type, trace);
            }

            if (currentToken.Type == TokenType2.NUMBER)
            {
                trace.AddRange(Number());
            }
            else if (currentToken.Type == TokenType2.FUNCTION)
            {
                trace.AddRange(Function());
            }
            else if (currentToken.Type == TokenType2.LPAREN)
            {
                Eat(TokenType2.LPAREN, trace);
                trace.AddRange(Expression());
                Eat(TokenType2.RPAREN, trace);
            }
            else
            {
                trace.Add($"[Ошибка: неожиданный токен {currentToken.Type}]");
                currentToken = lexer.GetNextToken();
            }

            return trace;
        }

        private List<string> Number()
        {
            var trace = new List<string> { "Вызов <ДробноеЧисло>" };
            Eat(TokenType2.NUMBER, trace);
            if (currentToken.Type == TokenType2.DOT)
            {
                Eat(TokenType2.DOT, trace);
                Eat(TokenType2.NUMBER, trace); // дробная часть
            }
            return trace;
        }

        private List<string> Function()
        {
            var trace = new List<string> { "Вызов <Функция>" };
            Eat(TokenType2.FUNCTION, trace);
            Eat(TokenType2.LPAREN, trace);
            trace.AddRange(Expression());
            Eat(TokenType2.RPAREN, trace);
            return trace;
        }
    }

}
