using PdfiumViewer;
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
    public partial class Otchet : Form
    {
        public Otchet(string name)
        {
            InitializeComponent();

            string pdfPath = Path.Combine(Application.StartupPath, name);

            if (File.Exists(pdfPath))
            {
                using (var document = PdfDocument.Load(pdfPath))
                {
                    int page = 0; // первая страница
                    var image = document.Render(page, pictureBox1.Width, pictureBox1.Height, true);
                    pictureBox1.Image = image;
                }
            }
            else
            {
                MessageBox.Show("Файл PDF не найден!");
            }
        }

        private void Otchet_Load(object sender, EventArgs e)
        {

        }
    }
}
