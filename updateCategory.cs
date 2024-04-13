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
    public partial class updateCategory : Form
    {
        public updateCategory()
        {
            InitializeComponent();
        }
        private readonly AmitJBDEntities _context = new AmitJBDEntities();
        private int _id;
        private BindingSource _bindingSource;
        private void button1_Click(object sender, EventArgs e)
        {
            var selectedCategory = _context.Categories.Where(q => q.Id == _id).FirstOrDefault();
            selectedCategory.CategoryName = textBox1.Text.Trim();

            _context.SaveChanges();
            _bindingSource.DataSource = _context.Categories.ToList();

            this.Close();
        }
        public updateCategory(int ID, BindingSource bindingSource) : this()
        {
            _id = ID;
            _bindingSource = bindingSource;
        }
        private void updateCategory_Load(object sender, EventArgs e)
        {
        }
    }
}
