namespace Kursach
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Create_ = new PictureBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            Create = new ToolStripMenuItem();
            Open = new ToolStripMenuItem();
            Save = new ToolStripMenuItem();
            Save_As = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            Back = new ToolStripMenuItem();
            Another = new ToolStripMenuItem();
            Cut = new ToolStripMenuItem();
            Copy = new ToolStripMenuItem();
            Paste = new ToolStripMenuItem();
            Remove = new ToolStripMenuItem();
            Select_all = new ToolStripMenuItem();
            текстToolStripMenuItem = new ToolStripMenuItem();
            Run = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            Open_ = new PictureBox();
            Save_ = new PictureBox();
            Back_ = new PictureBox();
            Another_ = new PictureBox();
            Run_ = new PictureBox();
            Cut_ = new PictureBox();
            Copy_ = new PictureBox();
            Paste_ = new PictureBox();
            richTextBox1 = new RichTextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Create_).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Open_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Save_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Back_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Another_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Run_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Cut_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Copy_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Paste_).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Create_
            // 
            Create_.Image = (Image)resources.GetObject("Create_.Image");
            Create_.Location = new Point(30, 50);
            Create_.Name = "Create_";
            Create_.Size = new Size(50, 48);
            Create_.SizeMode = PictureBoxSizeMode.StretchImage;
            Create_.TabIndex = 9;
            Create_.TabStop = false;
            Create_.Click += Create__Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem, текстToolStripMenuItem, Run, справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(799, 28);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Create, Open, Save, Save_As, Exit });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // Create
            // 
            Create.Name = "Create";
            Create.Size = new Size(192, 26);
            Create.Text = "Создать";
            Create.Click += Create__Click;
            // 
            // Open
            // 
            Open.Name = "Open";
            Open.Size = new Size(192, 26);
            Open.Text = "Открыть";
            Open.Click += Open__Click;
            // 
            // Save
            // 
            Save.Name = "Save";
            Save.Size = new Size(192, 26);
            Save.Text = "Сохранить";
            Save.Click += Save__Click;
            // 
            // Save_As
            // 
            Save_As.Name = "Save_As";
            Save_As.Size = new Size(192, 26);
            Save_As.Text = "Сохранить как";
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.Size = new Size(192, 26);
            Exit.Text = "Выход";
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Back, Another, Cut, Copy, Paste, Remove, Select_all });
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(74, 24);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // Back
            // 
            Back.Name = "Back";
            Back.Size = new Size(186, 26);
            Back.Text = "Отменить";
            // 
            // Another
            // 
            Another.Name = "Another";
            Another.Size = new Size(186, 26);
            Another.Text = "Повторить";
            Another.Click += Another_Click;
            // 
            // Cut
            // 
            Cut.Name = "Cut";
            Cut.Size = new Size(186, 26);
            Cut.Text = "Вырезать";
            Cut.Click += Menu_Cut;
            // 
            // Copy
            // 
            Copy.Name = "Copy";
            Copy.Size = new Size(186, 26);
            Copy.Text = "Копировать";
            Copy.Click += Menu_Copy;
            // 
            // Paste
            // 
            Paste.Name = "Paste";
            Paste.Size = new Size(186, 26);
            Paste.Text = "Вставить";
            Paste.Click += Menu_Paste;
            // 
            // Remove
            // 
            Remove.Name = "Remove";
            Remove.Size = new Size(186, 26);
            Remove.Text = "Удалить";
            // 
            // Select_all
            // 
            Select_all.Name = "Select_all";
            Select_all.Size = new Size(186, 26);
            Select_all.Text = "Выделить все";
            // 
            // текстToolStripMenuItem
            // 
            текстToolStripMenuItem.Name = "текстToolStripMenuItem";
            текстToolStripMenuItem.Size = new Size(59, 24);
            текстToolStripMenuItem.Text = "Текст";
            // 
            // Run
            // 
            Run.Name = "Run";
            Run.Size = new Size(55, 24);
            Run.Text = "Пуск";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // Open_
            // 
            Open_.Image = (Image)resources.GetObject("Open_.Image");
            Open_.Location = new Point(102, 50);
            Open_.Name = "Open_";
            Open_.Size = new Size(47, 48);
            Open_.SizeMode = PictureBoxSizeMode.StretchImage;
            Open_.TabIndex = 15;
            Open_.TabStop = false;
            Open_.Click += Open__Click;
            // 
            // Save_
            // 
            Save_.Image = (Image)resources.GetObject("Save_.Image");
            Save_.Location = new Point(172, 50);
            Save_.Name = "Save_";
            Save_.Size = new Size(47, 48);
            Save_.SizeMode = PictureBoxSizeMode.StretchImage;
            Save_.TabIndex = 16;
            Save_.TabStop = false;
            Save_.Click += Save__Click;
            // 
            // Back_
            // 
            Back_.Image = (Image)resources.GetObject("Back_.Image");
            Back_.Location = new Point(286, 50);
            Back_.Name = "Back_";
            Back_.Size = new Size(47, 48);
            Back_.SizeMode = PictureBoxSizeMode.StretchImage;
            Back_.TabIndex = 18;
            Back_.TabStop = false;
            Back_.Click += Back__Click;
            // 
            // Another_
            // 
            Another_.Image = (Image)resources.GetObject("Another_.Image");
            Another_.Location = new Point(353, 50);
            Another_.Name = "Another_";
            Another_.Size = new Size(47, 48);
            Another_.SizeMode = PictureBoxSizeMode.StretchImage;
            Another_.TabIndex = 19;
            Another_.TabStop = false;
            Another_.Click += Another__Click;
            // 
            // Run_
            // 
            Run_.Image = (Image)resources.GetObject("Run_.Image");
            Run_.Location = new Point(437, 50);
            Run_.Name = "Run_";
            Run_.Size = new Size(47, 48);
            Run_.SizeMode = PictureBoxSizeMode.StretchImage;
            Run_.TabIndex = 20;
            Run_.TabStop = false;
            Run_.Click += Run__Click;
            // 
            // Cut_
            // 
            Cut_.Image = (Image)resources.GetObject("Cut_.Image");
            Cut_.Location = new Point(509, 50);
            Cut_.Name = "Cut_";
            Cut_.Size = new Size(47, 48);
            Cut_.SizeMode = PictureBoxSizeMode.StretchImage;
            Cut_.TabIndex = 21;
            Cut_.TabStop = false;
            Cut_.Click += Menu_Cut;
            // 
            // Copy_
            // 
            Copy_.Image = (Image)resources.GetObject("Copy_.Image");
            Copy_.Location = new Point(575, 50);
            Copy_.Name = "Copy_";
            Copy_.Size = new Size(47, 48);
            Copy_.SizeMode = PictureBoxSizeMode.StretchImage;
            Copy_.TabIndex = 22;
            Copy_.TabStop = false;
            Copy_.Click += Menu_Copy;
            // 
            // Paste_
            // 
            Paste_.Image = (Image)resources.GetObject("Paste_.Image");
            Paste_.Location = new Point(642, 50);
            Paste_.Name = "Paste_";
            Paste_.Size = new Size(47, 48);
            Paste_.SizeMode = PictureBoxSizeMode.StretchImage;
            Paste_.TabIndex = 23;
            Paste_.TabStop = false;
            Paste_.Click += Menu_Paste;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(30, 127);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(757, 147);
            richTextBox1.TabIndex = 24;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += HighlightSyntax;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 297);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(757, 188);
            dataGridView1.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 497);
            Controls.Add(dataGridView1);
            Controls.Add(richTextBox1);
            Controls.Add(Paste_);
            Controls.Add(Copy_);
            Controls.Add(Cut_);
            Controls.Add(Run_);
            Controls.Add(Another_);
            Controls.Add(Back_);
            Controls.Add(Save_);
            Controls.Add(Open_);
            Controls.Add(Create_);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Create_).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Open_).EndInit();
            ((System.ComponentModel.ISupportInitialize)Save_).EndInit();
            ((System.ComponentModel.ISupportInitialize)Back_).EndInit();
            ((System.ComponentModel.ISupportInitialize)Another_).EndInit();
            ((System.ComponentModel.ISupportInitialize)Run_).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cut_).EndInit();
            ((System.ComponentModel.ISupportInitialize)Copy_).EndInit();
            ((System.ComponentModel.ISupportInitialize)Paste_).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox Create_;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem текстToolStripMenuItem;
        private ToolStripMenuItem Run;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private PictureBox Open_;
        private PictureBox Save_;
        private PictureBox Back_;
        private PictureBox Another_;
        private PictureBox Run_;
        private PictureBox Cut_;
        private PictureBox Copy_;
        private PictureBox Paste_;
        private ToolStripMenuItem Create;
        private ToolStripMenuItem Open;
        private ToolStripMenuItem Save;
        private ToolStripMenuItem Save_As;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem Back;
        private ToolStripMenuItem Another;
        private ToolStripMenuItem Cut;
        private ToolStripMenuItem Copy;
        private ToolStripMenuItem Paste;
        private ToolStripMenuItem Remove;
        private ToolStripMenuItem Select_all;
        private RichTextBox richTextBox1;
        private DataGridView dataGridView1;
    }
}
