namespace LibraryManagement
{
    partial class ChoseDatabaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoseDatabaceForm));
            cmb_ChoseDatabace = new ComboBox();
            btn_ChoseDatabace = new Button();
            cmb_choseType = new ComboBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            SuspendLayout();
            // 
            // cmb_ChoseDatabace
            // 
            cmb_ChoseDatabace.FormattingEnabled = true;
            cmb_ChoseDatabace.Items.AddRange(new object[] { "SQL", "List" });
            cmb_ChoseDatabace.Location = new Point(108, 145);
            cmb_ChoseDatabace.Name = "cmb_ChoseDatabace";
            cmb_ChoseDatabace.Size = new Size(151, 28);
            cmb_ChoseDatabace.TabIndex = 0;
            // 
            // btn_ChoseDatabace
            // 
            btn_ChoseDatabace.Location = new Point(108, 268);
            btn_ChoseDatabace.Name = "btn_ChoseDatabace";
            btn_ChoseDatabace.Size = new Size(151, 39);
            btn_ChoseDatabace.TabIndex = 1;
            btn_ChoseDatabace.Text = "انتخاب کنید ";
            btn_ChoseDatabace.UseVisualStyleBackColor = true;
            btn_ChoseDatabace.Click += btn_ChoseDatabace_Click;
            // 
            // cmb_choseType
            // 
            cmb_choseType.FormattingEnabled = true;
            cmb_choseType.Items.AddRange(new object[] { "کاربر جدید", "کتاب جدید", "مدیرت کتابخانه" });
            cmb_choseType.Location = new Point(108, 183);
            cmb_choseType.Name = "cmb_choseType";
            cmb_choseType.Size = new Size(151, 28);
            cmb_choseType.TabIndex = 2;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2BorderlessForm2
            // 
            guna2BorderlessForm2.ContainerControl = this;
            guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // ChoseDatabaceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 402);
            Controls.Add(cmb_choseType);
            Controls.Add(btn_ChoseDatabace);
            Controls.Add(cmb_ChoseDatabace);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChoseDatabaceForm";
            Text = "ChoseDatabaceForm";
            Load += ChoseDatabaceForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmb_ChoseDatabace;
        private Button btn_ChoseDatabace;
        private ComboBox cmb_choseType;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
    }
}