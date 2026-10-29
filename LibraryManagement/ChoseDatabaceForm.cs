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
            
            if (cmb_ChoseDatabace.Items.Count > 0 && cmb_ChoseDatabace.SelectedIndex == -1)
            {
                cmb_ChoseDatabace.SelectedIndex = 0;
            }
            if (cmb_choseType.Items.Count > 0 && cmb_choseType.SelectedIndex == -1) 
            {
                cmb_choseType.SelectedIndex = 0;
            }
        }

        private void btn_ChoseDatabace_Click(object sender, EventArgs e)
        {
            if (cmb_ChoseDatabace.SelectedItem == null)
            {
                MessageBox.Show("لطفاً نوع دیتابیس را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmb_choseType.SelectedIndex == null)
            {
                MessageBox.Show("لطفاً نوع کار خود را انتخاب کنید. ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string database = cmb_ChoseDatabace.SelectedItem.ToString().Trim();
            string userType = cmb_choseType.SelectedItem.ToString().Trim();


            if (!string.IsNullOrEmpty(database))
            {
                this.Hide();

                using (LibraryForm libraryForm = new LibraryForm(database))
                {
                    libraryForm.ShowDialog();
                }

                
                this.Close();
            }
            if (!string.IsNullOrEmpty(userType)) 
            {
                this.Hide();
                
            }
        }
    }
}
