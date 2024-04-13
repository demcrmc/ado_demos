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
    public partial class frmCategoryAdd : Form
    {
        AmitJBDEntities _context = new AmitJBDEntities();
        public frmCategoryAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category newCategory = new Category();
            newCategory.CategoryName = textBox1.Text.Trim();

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            this.Close();
        }
    }
}
