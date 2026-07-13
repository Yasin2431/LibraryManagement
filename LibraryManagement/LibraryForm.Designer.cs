namespace LibraryManagement
{
    partial class LibraryForm
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
            dgv_book = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Language = new DataGridViewTextBoxColumn();
            ISBN = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            PublishYear = new DataGridViewTextBoxColumn();
            btn_add = new Button();
            colDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_book).BeginInit();
            SuspendLayout();
            // 
            // dgv_book
            // 
            dgv_book.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_book.Columns.AddRange(new DataGridViewColumn[] { Title, Author, Language, ISBN, Category, PublishYear, colDelete });
            dgv_book.Dock = DockStyle.Bottom;
            dgv_book.Location = new Point(0, 72);
            dgv_book.Name = "dgv_book";
            dgv_book.RightToLeft = RightToLeft.Yes;
            dgv_book.RowHeadersWidth = 51;
            dgv_book.Size = new Size(979, 409);
            dgv_book.TabIndex = 0;
            dgv_book.CellContentClick += dgv_book_CellContentClick;
            // 
            // Title
            // 
            Title.DataPropertyName = "Title";
            Title.HeaderText = "نام اثر";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.Width = 125;
            // 
            // Author
            // 
            Author.DataPropertyName = "Author";
            Author.HeaderText = "نام نویسنده";
            Author.MinimumWidth = 6;
            Author.Name = "Author";
            Author.Width = 125;
            // 
            // Language
            // 
            Language.DataPropertyName = "Language";
            Language.HeaderText = "زبان";
            Language.MinimumWidth = 6;
            Language.Name = "Language";
            Language.Width = 125;
            // 
            // ISBN
            // 
            ISBN.DataPropertyName = "ISBN";
            ISBN.HeaderText = "کد بین المللی";
            ISBN.MinimumWidth = 6;
            ISBN.Name = "ISBN";
            ISBN.Width = 125;
            // 
            // Category
            // 
            Category.DataPropertyName = "Category";
            Category.HeaderText = "دسته بندی کتاب ";
            Category.MinimumWidth = 6;
            Category.Name = "Category";
            Category.Width = 125;
            // 
            // PublishYear
            // 
            PublishYear.DataPropertyName = "PublishYear";
            PublishYear.HeaderText = "سال انتشار";
            PublishYear.MinimumWidth = 6;
            PublishYear.Name = "PublishYear";
            PublishYear.Width = 125;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(12, 37);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(76, 29);
            btn_add.TabIndex = 1;
            btn_add.Text = "+";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "حذف";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.Width = 125;
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 481);
            Controls.Add(btn_add);
            Controls.Add(dgv_book);
            Name = "LibraryForm";
            Text = "LibraryForm";
            Load += LibraryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_book).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_book;
        private Button btn_add;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Language;
        private DataGridViewTextBoxColumn ISBN;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn PublishYear;
        private DataGridViewButtonColumn colDelete;
    }
}