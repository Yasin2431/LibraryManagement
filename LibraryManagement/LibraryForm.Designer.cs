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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryForm));
            dgv_book = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Language = new DataGridViewTextBoxColumn();
            ISBN = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            PublishYear = new DataGridViewTextBoxColumn();
            colDelete = new DataGridViewButtonColumn();
            colEdit = new DataGridViewButtonColumn();
            Id = new DataGridViewTextBoxColumn();
            btn_add = new Button();
            txt_search = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_book).BeginInit();
            SuspendLayout();
            // 
            // dgv_book
            // 
            dgv_book.BackgroundColor = SystemColors.ActiveBorder;
            dgv_book.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_book.Columns.AddRange(new DataGridViewColumn[] { Title, Author, Language, ISBN, Category, PublishYear, colDelete, colEdit, Id });
            dgv_book.Dock = DockStyle.Bottom;
            dgv_book.Location = new Point(0, 72);
            dgv_book.Name = "dgv_book";
            dgv_book.RightToLeft = RightToLeft.Yes;
            dgv_book.RowHeadersWidth = 51;
            dgv_book.Size = new Size(1024, 405);
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
            // colDelete
            // 
            colDelete.HeaderText = "حذف";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.Width = 125;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "ویرایش";
            colEdit.MinimumWidth = 6;
            colEdit.Name = "colEdit";
            colEdit.Width = 125;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Visible = false;
            Id.Width = 125;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(12, 33);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(76, 29);
            btn_add.TabIndex = 1;
            btn_add.Text = "+";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // txt_search
            // 
            txt_search.Location = new Point(94, 33);
            txt_search.Name = "txt_search";
            txt_search.RightToLeft = RightToLeft.Yes;
            txt_search.Size = new Size(799, 27);
            txt_search.TabIndex = 2;
            txt_search.TextChanged += txt_search_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(638, 33);
            label1.Name = "label1";
            label1.Size = new Size(255, 20);
            label1.TabIndex = 4;
            label1.Text = "جستجو اسم یا نویسنده یا کد بین المللی";
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 482);
            Controls.Add(label1);
            Controls.Add(txt_search);
            Controls.Add(btn_add);
            Controls.Add(dgv_book);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LibraryForm";
            Text = "LibraryForm";
            Load += LibraryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_book).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_book;
        private Button btn_add;
        private TextBox txt_search;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Language;
        private DataGridViewTextBoxColumn ISBN;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn PublishYear;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewTextBoxColumn Id;
    }
}
