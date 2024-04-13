using ado_demos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ado_demos
{
    public partial class Form1 : Form
    {
        AmitJBDEntities _context = new AmitJBDEntities();
        private int SelectedCategoryId; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AmitJBDEntities _context = new AmitJBDEntities();
            var result = _context.Categories.ToList();

            categoryBindingSource.DataSource = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCategoryAdd addForm = new frmCategoryAdd();
            addForm.ShowDialog();

            var result = _context.Categories.ToList();

            categoryBindingSource.DataSource = result;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            SelectedCategoryId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateCategory form = new updateCategory(SelectedCategoryId, categoryBindingSource);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    dataGridView1.Rows.RemoveAt(selectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
        
    }
}
