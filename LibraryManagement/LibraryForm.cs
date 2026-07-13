using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class LibraryForm : Form
    {
        LibraryManager libraryManager = new LibraryManager();
        public LibraryForm()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();

            dgv_book.DataSource = libraryManager.GetBooK().ToList();
        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {

        }

        private void dgv_book_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgv_book.Columns["colDelete"].Index)
            {
                int id = (int)dgv_book.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult result = MessageBox.Show(
                 "آیا از حذف این کتاب مطمئن هستید؟",
                 "حذف کتاب",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

                if (result == DialogResult.Yes) 
                    {
                    libraryManager.RemoveBook(id);
                    dgv_book.DataSource = libraryManager.GetBooK();
                    dgv_book.Refresh();
                     }
            }
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgv_book.Columns["colEdit"].Index)
            {
                int id = (int)dgv_book.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult result = MessageBox.Show(
                 "آیا از ویرایش این کتاب مطمئن هستید؟",
                 "ویرایش کتاب",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    AddForm editForm = new AddForm(id);
                    editForm.ShowDialog();
                }
                dgv_book.DataSource = libraryManager.GetBooK();
                dgv_book.Refresh();
            }


        }
    
    }
}
