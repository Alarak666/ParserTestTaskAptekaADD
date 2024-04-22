namespace Parser
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
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            Parsing = new Button();
            Fill = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            label4 = new Label();
            panel2 = new Panel();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            GridFile = new DataGridView();
            menuStrip1 = new MenuStrip();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toJsonToolStripMenuItem = new ToolStripMenuItem();
            JsonAll = new ToolStripMenuItem();
            toXmlToolStripMenuItem = new ToolStripMenuItem();
            XmlAll = new ToolStripMenuItem();
            toCvsToolStripMenuItem = new ToolStripMenuItem();
            CsvAll = new ToolStripMenuItem();
            Excel = new ToolStripMenuItem();
            ExecelAll = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridFile).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(951, 494);
            panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Size = new Size(951, 494);
            splitContainer1.SplitterDistance = 317;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(Parsing, 0, 0);
            tableLayoutPanel1.Controls.Add(Fill, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 55.0335579F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.9664421F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 379F));
            tableLayoutPanel1.Size = new Size(317, 494);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Parsing
            // 
            Parsing.Location = new Point(3, 3);
            Parsing.Name = "Parsing";
            Parsing.Size = new Size(311, 57);
            Parsing.TabIndex = 0;
            Parsing.Text = "Parsing";
            Parsing.UseVisualStyleBackColor = true;
            Parsing.Click += button1_Click;
            // 
            // Fill
            // 
            Fill.Dock = DockStyle.Fill;
            Fill.Location = new Point(3, 66);
            Fill.Name = "Fill";
            Fill.Size = new Size(311, 45);
            Fill.TabIndex = 1;
            Fill.Text = "Fill Grid";
            Fill.UseVisualStyleBackColor = true;
            Fill.Click += Fill_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(label4, 0, 0);
            tableLayoutPanel5.Controls.Add(panel2, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 117);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 37.4331551F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 346F));
            tableLayoutPanel5.Size = new Size(311, 374);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(305, 27);
            label4.TabIndex = 0;
            label4.Text = " ParsingToFile";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(checkBox4);
            panel2.Controls.Add(checkBox3);
            panel2.Controls.Add(checkBox2);
            panel2.Controls.Add(checkBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 341);
            panel2.TabIndex = 1;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Location = new Point(39, 134);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(65, 24);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "Excel";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(39, 104);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(53, 24);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Csv";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(39, 74);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(57, 24);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Xml";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(39, 44);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(59, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Json";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.5555573F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(GridFile, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 22.2672062F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 77.7327957F));
            tableLayoutPanel2.Size = new Size(630, 494);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 54.1353378F));
            tableLayoutPanel3.Size = new Size(624, 104);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(label2, 0, 1);
            tableLayoutPanel4.Controls.Add(label3, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(618, 98);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 49);
            label2.Name = "label2";
            label2.Size = new Size(612, 49);
            label2.TabIndex = 7;
            label2.Text = "Current Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(612, 49);
            label3.TabIndex = 6;
            label3.Text = "Total Category :";
            // 
            // GridFile
            // 
            GridFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridFile.Dock = DockStyle.Fill;
            GridFile.Location = new Point(3, 113);
            GridFile.Name = "GridFile";
            GridFile.RowHeadersWidth = 51;
            GridFile.Size = new Size(624, 378);
            GridFile.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { exportToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(951, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toJsonToolStripMenuItem, toXmlToolStripMenuItem, toCvsToolStripMenuItem, Excel });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(66, 24);
            exportToolStripMenuItem.Text = "Export";
            // 
            // toJsonToolStripMenuItem
            // 
            toJsonToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { JsonAll });
            toJsonToolStripMenuItem.Name = "toJsonToolStripMenuItem";
            toJsonToolStripMenuItem.Size = new Size(224, 26);
            toJsonToolStripMenuItem.Text = "To Json";
            // 
            // JsonAll
            // 
            JsonAll.Name = "JsonAll";
            JsonAll.Size = new Size(224, 26);
            JsonAll.Text = "All";
            JsonAll.Click += JsonAll_Click;
            // 
            // toXmlToolStripMenuItem
            // 
            toXmlToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { XmlAll });
            toXmlToolStripMenuItem.Name = "toXmlToolStripMenuItem";
            toXmlToolStripMenuItem.Size = new Size(224, 26);
            toXmlToolStripMenuItem.Text = "To Xml";
            // 
            // XmlAll
            // 
            XmlAll.Name = "XmlAll";
            XmlAll.Size = new Size(224, 26);
            XmlAll.Text = "All";
            XmlAll.Click += XmlAll_Click;
            // 
            // toCvsToolStripMenuItem
            // 
            toCvsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CsvAll });
            toCvsToolStripMenuItem.Name = "toCvsToolStripMenuItem";
            toCvsToolStripMenuItem.Size = new Size(224, 26);
            toCvsToolStripMenuItem.Text = "To Csv";
            // 
            // CsvAll
            // 
            CsvAll.Name = "CsvAll";
            CsvAll.Size = new Size(224, 26);
            CsvAll.Text = "All";
            CsvAll.Click += CsvAll_Click;
            // 
            // Excel
            // 
            Excel.DropDownItems.AddRange(new ToolStripItem[] { ExecelAll });
            Excel.Name = "Excel";
            Excel.Size = new Size(224, 26);
            Excel.Text = "To Excel";
            // 
            // ExecelAll
            // 
            ExecelAll.Name = "ExecelAll";
            ExecelAll.Size = new Size(224, 26);
            ExecelAll.Text = "All";
            ExecelAll.Click += ExecelAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 522);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridFile).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button Parsing;
        private TableLayoutPanel tableLayoutPanel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem toJsonToolStripMenuItem;
        private ToolStripMenuItem JsonAll;
        private ToolStripMenuItem toXmlToolStripMenuItem;
        private ToolStripMenuItem XmlAll;
        private ToolStripMenuItem toCvsToolStripMenuItem;
        private ToolStripMenuItem CsvAll;
        private ToolStripMenuItem Excel;
        private ToolStripMenuItem ExecelAll;
        private Button Fill;
        private DataGridView GridFile;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label4;
        private Panel panel2;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private Label label3;
    }
}
