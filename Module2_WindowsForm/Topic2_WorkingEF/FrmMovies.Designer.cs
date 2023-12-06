namespace Topic2_WorkingEF
{
    partial class FrmMovies
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvMovies = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            txtTitle = new TextBox();
            label3 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            cbDirector = new ComboBox();
            label5 = new Label();
            btnAdd = new Button();
            btnDeleteAll = new Button();
            txtSearch = new TextBox();
            label6 = new Label();
            btnSearch = new Button();
            txtYear = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtYear).BeginInit();
            SuspendLayout();
            // 
            // dgvMovies
            // 
            dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovies.Location = new Point(24, 406);
            dgvMovies.Name = "dgvMovies";
            dgvMovies.RowHeadersWidth = 51;
            dgvMovies.RowTemplate.Height = 29;
            dgvMovies.Size = new Size(1035, 319);
            dgvMovies.TabIndex = 0;
            dgvMovies.CellClick += dgvMovies_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(421, 23);
            label1.Name = "label1";
            label1.Size = new Size(254, 32);
            label1.TabIndex = 1;
            label1.Text = "Movies Management";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 93);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 2;
            label2.Text = "Movie title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(136, 87);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(313, 34);
            txtTitle.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 145);
            label3.Name = "label3";
            label3.Size = new Size(48, 28);
            label3.TabIndex = 4;
            label3.Text = "Year";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(686, 87);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(373, 151);
            txtDescription.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(545, 210);
            label4.Name = "label4";
            label4.Size = new Size(112, 28);
            label4.TabIndex = 6;
            label4.Text = "Description";
            // 
            // cbDirector
            // 
            cbDirector.FormattingEnabled = true;
            cbDirector.Location = new Point(136, 202);
            cbDirector.Name = "cbDirector";
            cbDirector.Size = new Size(313, 36);
            cbDirector.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 210);
            label5.Name = "label5";
            label5.Size = new Size(83, 28);
            label5.TabIndex = 9;
            label5.Text = "Director";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(341, 275);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 43);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new Point(517, 275);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(140, 43);
            btnDeleteAll.TabIndex = 11;
            btnDeleteAll.Text = "Delete all";
            btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(259, 348);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(561, 34);
            txtSearch.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(136, 351);
            label6.Name = "label6";
            label6.Size = new Size(96, 28);
            label6.TabIndex = 12;
            label6.Text = "Enter title";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(842, 348);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(140, 34);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(136, 143);
            txtYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(150, 34);
            txtYear.TabIndex = 15;
            // 
            // FrmMovies
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 737);
            Controls.Add(txtYear);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label6);
            Controls.Add(btnDeleteAll);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(cbDirector);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtTitle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvMovies);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "FrmMovies";
            Text = "Form Movies";
            Load += FrmMovies_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMovies;
        private Label label1;
        private Label label2;
        private TextBox txtTitle;
        private Label label3;
        private TextBox txtDescription;
        private Label label4;
        private ComboBox cbDirector;
        private Label label5;
        private Button btnAdd;
        private Button btnDeleteAll;
        private TextBox txtSearch;
        private Label label6;
        private Button btnSearch;
        private NumericUpDown txtYear;
    }
}