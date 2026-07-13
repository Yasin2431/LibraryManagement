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

        }
    }
}
