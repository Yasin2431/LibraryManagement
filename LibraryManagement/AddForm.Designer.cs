namespace LibraryManagement
{
    partial class AddForm
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
            txt_title = new TextBox();
            txt_author = new TextBox();
            cmb_language = new ComboBox();
            txt_isbn = new TextBox();
            cmb_category = new ComboBox();
            cmb_pulisheryear = new ComboBox();
            btn_add = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txt_title
            // 
            txt_title.Location = new Point(109, 38);
            txt_title.Name = "txt_title";
            txt_title.Size = new Size(194, 27);
            txt_title.TabIndex = 0;
            // 
            // txt_author
            // 
            txt_author.Location = new Point(109, 71);
            txt_author.Name = "txt_author";
            txt_author.Size = new Size(194, 27);
            txt_author.TabIndex = 1;
            // 
            // cmb_language
            // 
            cmb_language.FormattingEnabled = true;
            cmb_language.Location = new Point(109, 104);
            cmb_language.Name = "cmb_language";
            cmb_language.Size = new Size(194, 28);
            cmb_language.TabIndex = 3;
            // 
            // txt_isbn
            // 
            txt_isbn.Location = new Point(109, 138);
            txt_isbn.Name = "txt_isbn";
            txt_isbn.Size = new Size(194, 27);
            txt_isbn.TabIndex = 4;
            // 
            // cmb_category
            // 
            cmb_category.FormattingEnabled = true;
            cmb_category.Location = new Point(109, 171);
            cmb_category.Name = "cmb_category";
            cmb_category.Size = new Size(194, 28);
            cmb_category.TabIndex = 5;
            // 
            // cmb_pulisheryear
            // 
            cmb_pulisheryear.FormattingEnabled = true;
            cmb_pulisheryear.Location = new Point(109, 205);
            cmb_pulisheryear.Name = "cmb_pulisheryear";
            cmb_pulisheryear.Size = new Size(194, 28);
            cmb_pulisheryear.TabIndex = 6;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(309, 269);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(94, 29);
            btn_add.TabIndex = 8;
            btn_add.Text = "اضافه کردن ";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 9;
            label1.Text = ":نام اثر";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightGray;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 10;
            label2.Text = ":نام نویسنده";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGray;
            label3.Location = new Point(309, 104);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 11;
            label3.Text = ":زبان اثر";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightGray;
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 12;
            label4.Text = ":کدبین المللی اثر ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightGray;
            label5.Location = new Point(309, 171);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 13;
            label5.Text = ":دسته بندی اثر ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightGray;
            label6.Location = new Point(309, 205);
            label6.Name = "label6";
            label6.Size = new Size(103, 20);
            label6.TabIndex = 14;
            label6.Text = ":سال انتشار اثر ";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Location = new Point(307, 138);
            panel1.Name = "panel1";
            panel1.Size = new Size(123, 27);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Location = new Point(307, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(96, 27);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Location = new Point(307, 38);
            panel3.Name = "panel3";
            panel3.Size = new Size(58, 27);
            panel3.TabIndex = 17;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(464, 340);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(btn_add);
            Controls.Add(cmb_pulisheryear);
            Controls.Add(cmb_category);
            Controls.Add(txt_isbn);
            Controls.Add(cmb_language);
            Controls.Add(txt_author);
            Controls.Add(txt_title);
            Name = "AddForm";
            Text = "AddForm";
            Load += AddForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_title;
        private TextBox txt_author;
        private ComboBox cmb_language;
        private TextBox txt_isbn;
        private ComboBox cmb_category;
        private ComboBox cmb_pulisheryear;
        private Button btn_add;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}