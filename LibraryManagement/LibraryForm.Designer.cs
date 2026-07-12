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
            btn_add = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_book).BeginInit();
            SuspendLayout();
            // 
            // dgv_book
            // 
            dgv_book.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_book.Dock = DockStyle.Bottom;
            dgv_book.Location = new Point(0, 72);
            dgv_book.Name = "dgv_book";
            dgv_book.RowHeadersWidth = 51;
            dgv_book.Size = new Size(797, 409);
            dgv_book.TabIndex = 0;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(709, 37);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(76, 29);
            btn_add.TabIndex = 1;
            btn_add.Text = "+";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 481);
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
    }
}