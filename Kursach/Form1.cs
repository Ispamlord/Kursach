using Kursach.Compilier;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursach
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Stack<string> history = new Stack<string>();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            richTextBox1.TextChanged += OnTextChanged;
            FormClosing += Save__Click;
        }

        private void Another_Click(object sender, EventArgs e)
        {

        }

        private void Open__Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void Create__Click(object sender, EventArgs e)
        {

        }

        private void Save__Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void StoreCurrentState()
        {
            if (history.Count == 0 || history.Peek() != richTextBox1.Text)
            {
                history.Push(richTextBox1.Text);
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            StoreCurrentState();
            int selectionStart = richTextBox1.SelectionStart;
            int selectionLength = richTextBox1.SelectionLength;

            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;

            foreach (var word in keywords)
            {
                int startIndex = 0;
                while ((startIndex = richTextBox1.Text.IndexOf(word.Key, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    richTextBox1.Select(startIndex, word.Key.Length);
                    richTextBox1.SelectionColor = word.Value;
                    startIndex += word.Key.Length;
                }
            }

            richTextBox1.SelectionStart = selectionStart;
            richTextBox1.SelectionLength = selectionLength;
            richTextBox1.SelectionColor = Color.Black;
        }
        public void Undo()
        {
            if (history.Count > 1)
            {
                history.Pop();
                richTextBox1.Text = history.Peek(); 
                richTextBox1.SelectionStart = richTextBox1.Text.Length; 
            }
        }
        private void Back__Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void Another__Click(object sender, EventArgs e)
        {

        }

        private void Run__Click(object sender, EventArgs e)
        {
            Scan1 scan = new Scan1(richTextBox1.Text);
        }

         
        private Dictionary<string, Color> keywords = new Dictionary<string, Color>
        {
            { "struct", Color.Green },
            { "int", Color.Red },
            { "string", Color.Red },
            { "double", Color.Red },
            { "float", Color.Red },
            { "public", Color.Purple },
            { "private", Color.Purple },
            { "protected", Color.Purple },
            { "{", Color.DarkGray },
            { "}", Color.DarkGray },
            { ";", Color.DarkGray }
        };



        public void HighlightSyntax(object sender, EventArgs e)
        {
            int selectionStart = richTextBox1.SelectionStart; 
            int selectionLength = richTextBox1.SelectionLength;

            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black; 

            foreach (var word in keywords)
            {
                int startIndex = 0;
                while ((startIndex = richTextBox1.Text.IndexOf(word.Key, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    richTextBox1.Select(startIndex, word.Key.Length);
                    richTextBox1.SelectionColor = word.Value;
                    startIndex += word.Key.Length;
                }
            }

            richTextBox1.SelectionStart = selectionStart;
            richTextBox1.SelectionLength = selectionLength;
            richTextBox1.SelectionColor = Color.Black;
        }
        private void Menu_Copy(System.Object sender, System.EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
                richTextBox1.Copy();
        }

        private void Menu_Cut(System.Object sender, System.EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Cut();
        }

        private void Menu_Paste(System.Object sender, System.EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                }
                richTextBox1.Paste();
            }
        }

        private void Menu_Undo(System.Object sender, System.EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
