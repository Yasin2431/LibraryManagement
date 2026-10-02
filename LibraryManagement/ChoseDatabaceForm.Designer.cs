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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoseDatabaceForm));
            cmb_Chose = new ComboBox();
            btn_ChoseDatabace = new Button();
            SuspendLayout();
            // 
            // cmb_Chose
            // 
            cmb_Chose.FormattingEnabled = true;
            cmb_Chose.Items.AddRange(new object[] { "SQL", "List" });
            cmb_Chose.Location = new Point(108, 145);
            cmb_Chose.Name = "cmb_Chose";
            cmb_Chose.Size = new Size(151, 28);
            cmb_Chose.TabIndex = 0;
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
            // ChoseDatabaceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 402);
            Controls.Add(btn_ChoseDatabace);
            Controls.Add(cmb_Chose);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChoseDatabaceForm";
            Text = "ChoseDatabaceForm";
            Load += ChoseDatabaceForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmb_Chose;
        private Button btn_ChoseDatabace;
    }
}