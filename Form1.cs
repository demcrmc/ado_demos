﻿using ado_demos.Entities;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Category newCategory = new Category();
            newCategory.CategoryName = textBox1.Text.Trim();

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            categoryBindingSource.DataSource = _context.Categories.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchText = textBox2.Text.Trim();

            var result = _context.Categories
                        .Where(q => q.CategoryName.Contains(searchText))
                        .ToList();

            categoryBindingSource.DataSource = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string toBeDeleted = textBox3.Text.Trim();
            var itemToDelete = _context.Categories
                                .Where(q => q.Id.ToString() == toBeDeleted)
                                .FirstOrDefault();

            _context.Categories.Remove(itemToDelete);
            _context.SaveChanges();

            categoryBindingSource.DataSource = _context.Categories.ToList();
        }
    }
}
