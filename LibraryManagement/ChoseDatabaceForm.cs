using System;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class ChoseDatabaceForm : Form
    {
        public ChoseDatabaceForm()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void ChoseDatabaceForm_Load(object sender, EventArgs e)
        {
            // انتخاب پیش‌فرض اولین گزینه در صورت خالی نبودن لیست
            if (cmb_Chose.Items.Count > 0 && cmb_Chose.SelectedIndex == -1)
            {
                cmb_Chose.SelectedIndex = 0;
            }
        }

        private void btn_ChoseDatabace_Click(object sender, EventArgs e)
        {
            if (cmb_Chose.SelectedItem == null)
            {
                MessageBox.Show("لطفاً نوع دیتابیس را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string database = cmb_Chose.SelectedItem.ToString().Trim();

            if (!string.IsNullOrEmpty(database))
            {
                this.Hide();

                using (LibraryForm libraryForm = new LibraryForm(database))
                {
                    libraryForm.ShowDialog();
                }

                // پس از بستن فرم اصلی، کل برنامه خاتمه پیدا می‌کند
                this.Close();
            }
        }
    }
}
