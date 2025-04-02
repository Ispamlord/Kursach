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
        private PictureBox lineNumbers;
        private Panel panel;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            richTextBox1.TextChanged += OnTextChanged;
            FormClosing += Save__Click;
            richTextBox1.VScroll += richTextBox1_VScroll;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Строка";
            dataGridView1.Columns[1].Name = "Позиция";
            dataGridView1.Columns[2].Name = "Лексема";
            dataGridView1.Columns[3].Name = "Тип";
        }
        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            UpdateLineNumbers();
        }
        private void Another_Click(object sender, EventArgs e)
        {

        }

        private void SaveCurrentFile()
        {
            if (richTextBox1.TextLength > 0)
            {
                DialogResult result = MessageBox.Show("Сохранить текущий файл?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return;

                if (result == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                        MessageBox.Show("Файл сохранен");
                    }
                }
            }
        }

        private void Open__Click(object sender, EventArgs e)
        {
            SaveCurrentFile();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void Create__Click(object sender, EventArgs e)
        {
            SaveCurrentFile();

            richTextBox1.Clear();
            MessageBox.Show("Новый файл создан");
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
            UpdateLineNumbers();
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
            dataGridView1.Rows.Clear();
            Scan scan = new Scan(richTextBox1.Text);
            scan.Lexic();
            for (int i = 0; i < scan.codes.Count; i++) {
                dataGridView1.Rows.Add(scan.codes[i], scan.keywords[i], scan.keyword[i]);
            }
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

        private void UpdateLineNumbers()
        {
            Point pt = new Point(0, 0);
            int firstIndex = richTextBox1.GetCharIndexFromPosition(pt);
            int firstLine = richTextBox1.GetLineFromCharIndex(firstIndex);

            int totalLines = richTextBox1.Lines.Length;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                for (int i = 0; i < totalLines; i++)
                {
                    int y = (i - firstLine) * richTextBox1.Font.Height;
                    if (y >= 0 && y < pictureBox1.Height)
                    {
                        g.DrawString((i + 1).ToString(), richTextBox1.Font, Brushes.Black, new PointF(0, y));
                    }
                }
            }
            pictureBox1.Image = bmp;
        }

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

        private void UpSize_Click(object sender, EventArgs e)
        {
            ChangeFontSize(2);
        }
        private void ChangeFontSize(float delta)
        {
            if (richTextBox1.Font != null)
            {
                float newSize = Math.Max(6, richTextBox1.Font.Size + delta);
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, newSize);
            }

            if (dataGridView1.Font != null)
            {
                float newSize = Math.Max(6, dataGridView1.Font.Size + delta);
                dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, newSize);
            }
        }

        private void DownSize_Click(object sender, EventArgs e)
        {
            ChangeFontSize(-2);
        }
    }
}
