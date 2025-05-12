using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Compilier
{
    public enum TokenType
    {
        ID,
        ASSIGN,
        PLUS,
        MINUS,
        MULTIPLY,
        SEMICOLON,
        EOF
    }

    public class Tokenq
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Tokenq(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }

    public class Lexer
    {
        private readonly string _text;
        private int _pos;
        private readonly int _length;

        public Lexer(string text)
        {
            _text = text;
            _length = text.Length;
            _pos = 0;
        }

        private char CurrentChar => _pos < _length ? _text[_pos] : '\0';

        private void Advance()
        {
            _pos++;
        }

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(CurrentChar))
            {
                Advance();
            }
        }

        private string Id()
        {
            StringBuilder result = new StringBuilder();
            if (!char.IsLetter(CurrentChar))
                throw new Exception($"Лексическая ошибка: Ожидалась буква, а найдено '{CurrentChar}'");

            while (char.IsLetterOrDigit(CurrentChar))
            {
                result.Append(CurrentChar);
                Advance();
            }
            return result.ToString();
        }

        public Tokenq GetNextToken()
        {
            while (CurrentChar != '\0')
            {
                if (char.IsWhiteSpace(CurrentChar))
                {
                    SkipWhitespace();
                    continue;
                }

                if (char.IsLetter(CurrentChar))
                    return new Tokenq(TokenType.ID, Id());

                if (CurrentChar == '=')
                {
                    Advance();
                    return new Tokenq(TokenType.ASSIGN, "=");
                }

                if (CurrentChar == '+')
                {
                    Advance();
                    return new Tokenq(TokenType.PLUS, "+");
                }

                if (CurrentChar == '-')
                {
                    Advance();
                    return new Tokenq(TokenType.MINUS, "-");
                }

                if (CurrentChar == '*')
                {
                    Advance();
                    return new Tokenq(TokenType.MULTIPLY, "*");
                }

                if (CurrentChar == ';')
                {
                    Advance();
                    return new Tokenq(TokenType.SEMICOLON, ";");
                }

                throw new Exception($"Лексическая ошибка: Недопустимый символ '{CurrentChar}'");
            }

            return new Tokenq(TokenType.EOF, string.Empty);
        }
    }

    public class Tetrad
    {
        public string Op { get; set; }
        public string Arg1 { get; set; }
        public string Arg2 { get; set; }
        public string Result { get; set; }

        public bool IsError { get; set; } = false;

        public Tetrad(string op, string arg1, string arg2, string result)
        {
            Op = op;
            Arg1 = arg1;
            Arg2 = arg2;
            Result = result;
        }

        public Tetrad(string errorMessage)
        {
            IsError = true;
            Op = "Ошибка";
            Arg1 = errorMessage;
            Arg2 = "";
            Result = "";
        }
    }

    public class ErrorMessage
    {
        public string Message { get; set; }
    }

    public class Parser
    {
        private readonly Lexer _lexer;
        private Tokenq _currentToken;
        public List<Tetrad> Tetrads { get; private set; }

        public Parser(Lexer lexer)
        {
            _lexer = lexer;
            _currentToken = _lexer.GetNextToken();
            Tetrads = new List<Tetrad>();
        }

        public void Parse()
        {
            string id = _currentToken.Value;
            Eat(TokenType.ID);
            Eat(TokenType.ASSIGN);
            string exprResult = Expr();

            if (_currentToken.Type != TokenType.SEMICOLON)
            {
                Tetrads.Add(new Tetrad("Отсутствует ';' в конце выражения. Программа не будет работать."));
                return;
            }

            Eat(TokenType.SEMICOLON);

            Tetrads.Add(new Tetrad("=", exprResult, "", id));
        }

        private void Eat(TokenType type)
        {
            if (_currentToken.Type == type)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else
            {
                Tetrads.Add(new Tetrad($"Ожидался токен {type}, но получен {_currentToken.Type}"));
            }
        }

        private string Expr()
        {
            string left = Term();

            while (_currentToken.Type == TokenType.PLUS || _currentToken.Type == TokenType.MINUS)
            {
                TokenType op = _currentToken.Type;
                Eat(op);
                string right = Term();
                string temp = NewTemp();
                string opStr = op == TokenType.PLUS ? "+" : "-";
                Tetrads.Add(new Tetrad(opStr, left, right, temp));
                left = temp;
            }

            return left;
        }

        private string Term()
        {
            string left = Factor();

            while (_currentToken.Type == TokenType.MULTIPLY)
            {
                Eat(TokenType.MULTIPLY);
                string right = Factor();
                string temp = NewTemp();
                Tetrads.Add(new Tetrad("*", left, right, temp));
                left = temp;
            }

            return left;
        }

        private string Factor()
        {
            if (_currentToken.Type == TokenType.MINUS)
            {
                Eat(TokenType.MINUS);
                string factor = Factor();
                string temp = NewTemp();
                Tetrads.Add(new Tetrad("minus", factor, "", temp));
                return temp;
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                string value = _currentToken.Value;
                Eat(TokenType.ID);
                return value;
            }
            else
            {
                Tetrads.Add(new Tetrad("Ожидался идентификатор или унарный минус."));
                return "";
            }
        }

        private int _tempIndex = 0;

        private string NewTemp()
        {
            _tempIndex++;
            return $"t{_tempIndex}";
        }
    }



}

