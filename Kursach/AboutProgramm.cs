using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class AboutProgramm : Form
    {
        public AboutProgramm()
        {
            InitializeComponent();
            var webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                DocumentText = htmlContent
            };
            this.Text = "О программе";
            this.Width = 750;
            this.Height = 500;

            this.Controls.Add(webBrowser);
        }

        private void AboutProgramm_Load(object sender, EventArgs e)
        {

        }
        private string htmlContent = @"<!DOCTYPE html>
<html lang=""ru"">
<head>
    <meta charset=""UTF-8"">
    <title>О программе</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: #f9f9f9;
            color: #333;
            margin: 40px;
        }

        .container {
            background: white;
            padding: 30px;
            border-radius: 10px;
            max-width: 600px;
            margin: auto;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        h1 {
            color: #0078D7;
            margin-bottom: 10px;
        }

        p {
            line-height: 1.5;
        }

        .footer {
            margin-top: 30px;
            font-size: 0.9em;
            color: gray;
        }
    </style>
</head>
<body>
    <div class=""container"">
        <h1>О программе</h1>
        <p><strong>Название:</strong> Парсер Структуры</p>
        <p><strong>Версия:</strong> 1.0</p>
        <p><strong>Описание:</strong> Программа предназначена для анализа и обработки структур, написанных на языке C#. Она выполняет лексический и синтаксический анализ введённого пользователем кода, определяет ошибки. Она разработана в рамках учебного проекта.</p>
        <p><strong>Автор:</strong> Серов Данил Александрович</p>
        <p><strong>Проверяющий:</strong> Шорников Юрий Владимирович</p>
        <div class=""footer"">© 2025 Все права защищены</div>
    </div>
</body>
</html>
";
    }
}
