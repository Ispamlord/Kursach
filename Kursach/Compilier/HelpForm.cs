using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach.Compilier
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            var webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                DocumentText = htmlContent
            };

            this.Text = "Справка";
            this.Width = 750;
            this.Height = 500;

            this.Controls.Add(webBrowser);
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {

        }
        private string htmlContent = @"<!DOCTYPE html>
<html lang=""ru"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Справка по текстовому редактору</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            line-height: 1.6;
        }
        h1, h2 {
            color: #2c3e50;
        }
        ul {
            list-style-type: disc;
            margin-left: 20px;
        }
        pre {
            background-color: #f4f4f4;
            padding: 10px;
            border-radius: 5px;
        }
        .menu-section {
            margin-bottom: 20px;
        }
        .section-header {
            font-size: 1.2em;
            font-weight: bold;
        }
        .sub-section {
            margin-left: 20px;
        }
    </style>
</head>
<body>

    <h1>Справка по текстовому редактору</h1>

    <div class=""menu-section"">
        <h2 class=""section-header"">Пункты меню</h2>
        <ul>
            <li><b>Файл → Создать:</b> Создает новый файл с пустым текстовым файлом. Имя файла по умолчанию — ""NewFileN.txt"", где N — номер следующего файла.</li>
            <li><b>Файл → Открыть:</b> Открывает диалог для выбора текстового файла, который затем отображается в новой вкладке с именем файла.</li>
            <li><b>Файл → Сохранить:</b> Сохраняет содержимое текущей вкладки. Если файл уже имеет путь, сохраняет по нему; иначе открывает диалог ""Сохранить как"".</li>
            <li><b>Файл → Сохранить как:</b> Открывает диалог для сохранения текущей вкладки под новым именем и в новом месте.</li>
            <li><b>Файл → Выход:</b> Закрывает приложение с запросом сохранения всех измененных вкладок.</li>
            <li><b>Правка → Отменить:</b> Отменяет последнее действие в текущей вкладке (например, удаление текста).</li>
            <li><b>Правка → Повторить:</b> Повторяет отмененное действие в текущей вкладке.</li>
            <li><b>Правка → Вырезать:</b> Вырезает выделенный текст из текущей вкладки в буфер обмена.</li>
            <li><b>Правка → Копировать:</b> Копирует выделенный текст в буфер обмена.</li>
            <li><b>Правка → Вставить:</b> Вставляет текст из буфера обмена в текущую вкладку.</li>
            <li><b>Правка → Удалить:</b> Удаляет выделенный текст в текущей вкладке.</li>
            <li><b>Правка → Выделить все:</b> Выделяет весь текст в текущей вкладке.</li>
            <li><b>Пуск:</b> Запуск парсера.</li>
            <li><b>Справка → Справка:</b> Открывает этот документ с описанием функций приложения.</li>
            <li><b>Справка → О программе:</b> Показывает окно с информацией о программе (версия, автор).</li>
        </ul>
    </div>

    <div class=""menu-section"">
        <h2 class=""section-header"">Перетаскивание файлов</h2>
        <p>Перетаскивание файла из проводника в область ввода открывает его как новую вкладку. Размер шрифта текста можно изменять через меню ""Разное"".</p>
    </div>

    <div class=""menu-section"">
        <h2 class=""section-header"">Область ввода текста</h2>
        <p>Область ввода текста расположена в центральной части окна и представлена вкладками. Каждая вкладка соответствует открытому файлу и содержит:</p>
        <ul>
            <li><b>Номера строк:</b> Слева от текста отображаются номера строк, которые автоматически обновляются при добавлении или удалении строк. Прокрутка номеров синхронизирована с текстом.</li>
            <li><b>Текстовый редактор:</b> Основная область для ввода и редактирования текста. Поддерживает многострочный ввод, табуляцию и прокрутку при превышении видимой области.</li>
        </ul>
    </div>

    <div class=""menu-section"">
        <h2 class=""section-header"">Область вывода результатов</h2>
        <p>Область вывода результатов находится в нижней части окна под разделителем. Она предназначена для отображения информации о работе парсера. Основные особенности:</p>
        <ul>
            <li><b>Только чтение:</b> Текст в этой области нельзя редактировать напрямую.</li>
            <li><b>Прокрутка:</b> При большом объеме текста появляется полоса прокрутки.</li>
        </ul>
    </div>

</body>
</html>

";
    }
}
