namespace UI
{
    partial class AddUserForm
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
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panel2 = new Panel();
            label2 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            btn_add = new Button();
            txt_phonenumber = new TextBox();
            txt_lastname = new TextBox();
            txt_firstname = new TextBox();
            txt_nationalnode = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            btn_picture = new Button();
            panel3 = new Panel();
            panel5 = new Panel();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Location = new Point(278, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(109, 27);
            panel2.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightGray;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 10;
            label2.Text = ": نام خانوادگی";
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Location = new Point(278, 140);
            panel4.Name = "panel4";
            panel4.Size = new Size(100, 27);
            panel4.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightGray;
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 12;
            label4.Text = ": شماره تلفن";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(278, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(44, 27);
            panel1.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 9;
            label1.Text = ": نام";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(274, 272);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(94, 29);
            btn_add.TabIndex = 24;
            btn_add.Text = "اضافه کردن ";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // txt_phonenumber
            // 
            txt_phonenumber.Location = new Point(80, 140);
            txt_phonenumber.Name = "txt_phonenumber";
            txt_phonenumber.Size = new Size(194, 27);
            txt_phonenumber.TabIndex = 21;
            // 
            // txt_lastname
            // 
            txt_lastname.Location = new Point(80, 73);
            txt_lastname.Name = "txt_lastname";
            txt_lastname.Size = new Size(194, 27);
            txt_lastname.TabIndex = 19;
            // 
            // txt_firstname
            // 
            txt_firstname.Location = new Point(80, 40);
            txt_firstname.Name = "txt_firstname";
            txt_firstname.Size = new Size(194, 27);
            txt_firstname.TabIndex = 18;
            // 
            // txt_nationalnode
            // 
            txt_nationalnode.Location = new Point(80, 107);
            txt_nationalnode.Name = "txt_nationalnode";
            txt_nationalnode.Size = new Size(194, 27);
            txt_nationalnode.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGray;
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 11;
            label3.Text = ": کد ملی";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(156, 102);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // btn_picture
            // 
            btn_picture.Location = new Point(274, 173);
            btn_picture.Name = "btn_picture";
            btn_picture.Size = new Size(94, 29);
            btn_picture.TabIndex = 33;
            btn_picture.Text = "عکس";
            btn_picture.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Location = new Point(281, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(72, 27);
            panel3.TabIndex = 35;
            // 
            // panel5
            // 
            panel5.Controls.Add(pictureBox1);
            panel5.Location = new Point(80, 172);
            panel5.Name = "panel5";
            panel5.Size = new Size(163, 110);
            panel5.TabIndex = 36;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 340);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(btn_picture);
            Controls.Add(txt_nationalnode);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(btn_add);
            Controls.Add(txt_phonenumber);
            Controls.Add(txt_lastname);
            Controls.Add(txt_firstname);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            Text = "UserForm";
            Load += AddUserForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Panel panel2;
        private Label label2;
        private Panel panel4;
        private Label label4;
        private Panel panel1;
        private Label label1;
        private Button btn_add;
        private ComboBox cmb_pulisheryear;
        private ComboBox cmb_category;
        private TextBox txt_phonenumber;
        private TextBox txt_lastname;
        private TextBox txt_firstname;
        private TextBox txt_nationalnode;
        private Label label3;
        private PictureBox pictureBox1;
        private Button btn_picture;
        private Panel panel3;
        private Panel panel5;
    }
}