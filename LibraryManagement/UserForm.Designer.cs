namespace UI
{
    partial class UserForm
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
            label1 = new Label();
            txt_search = new TextBox();
            btn_add = new Button();
            dgv_member = new DataGridView();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            NationalCode = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            colPhoto = new DataGridViewImageColumn();
            colDelete = new DataGridViewButtonColumn();
            colEdit = new DataGridViewButtonColumn();
            Id = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_member).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(780, 17);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 8;
            label1.Text = "جستجو نام کاربر";
            label1.Click += label1_Click;
            // 
            // txt_search
            // 
            txt_search.Location = new Point(94, 17);
            txt_search.Name = "txt_search";
            txt_search.RightToLeft = RightToLeft.Yes;
            txt_search.Size = new Size(799, 27);
            txt_search.TabIndex = 7;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(12, 17);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(76, 29);
            btn_add.TabIndex = 6;
            btn_add.Text = "+";
            btn_add.UseVisualStyleBackColor = true;
            // 
            // dgv_member
            // 
            dgv_member.BackgroundColor = SystemColors.ActiveBorder;
            dgv_member.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_member.Columns.AddRange(new DataGridViewColumn[] { FirstName, LastName, NationalCode, PhoneNumber, colPhoto, colDelete, colEdit, Id });
            dgv_member.Dock = DockStyle.Bottom;
            dgv_member.Location = new Point(0, 77);
            dgv_member.Name = "dgv_member";
            dgv_member.RightToLeft = RightToLeft.Yes;
            dgv_member.RowHeadersWidth = 51;
            dgv_member.Size = new Size(1024, 405);
            dgv_member.TabIndex = 5;
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "نام";
            FirstName.MinimumWidth = 6;
            FirstName.Name = "FirstName";
            FirstName.Width = 125;
            // 
            // LastName
            // 
            LastName.DataPropertyName = "LastName";
            LastName.HeaderText = "نام خانوادگی";
            LastName.MinimumWidth = 6;
            LastName.Name = "LastName";
            LastName.Width = 125;
            // 
            // NationalCode
            // 
            NationalCode.DataPropertyName = "NationalCode";
            NationalCode.HeaderText = "کد ملی";
            NationalCode.MinimumWidth = 6;
            NationalCode.Name = "NationalCode";
            NationalCode.Width = 125;
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "شماره تلفن";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Width = 125;
            // 
            // colPhoto
            // 
            colPhoto.DataPropertyName = "Photo";
            colPhoto.HeaderText = "تصویر";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.MinimumWidth = 6;
            colPhoto.Name = "colPhoto";
            colPhoto.Width = 125;
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
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 482);
            Controls.Add(label1);
            Controls.Add(txt_search);
            Controls.Add(btn_add);
            Controls.Add(dgv_member);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_member).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_search;
        private Button btn_add;
        private DataGridView dgv_member;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn NationalCode;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewImageColumn colPhoto;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewTextBoxColumn Id;
    }
}