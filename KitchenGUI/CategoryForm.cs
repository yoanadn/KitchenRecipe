using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitchenGUI
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryContext categoryContext;

        public CategoryForm(CategoryContext context)
        {
            InitializeComponent();
            categoryContext = context;
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = categoryContext.ReadAll()
                .OrderBy(c => c.Name) 
                .Select((c, index) => new
                {
                    No = index + 1,     
                    c.Name              
                })
                .ToList();

            dgvCategories.DataSource = categories;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            var allCategories = categoryContext.ReadAll();
            bool alreadyExists = allCategories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
            {
                MessageBox.Show("This category already exists.");
                return;
            }

            var category = new Category { Name = name };
            categoryContext.Create(category);
            LoadCategories();
            txtCategoryName.Clear();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string nameToDelete = txtCategoryName.Text.Trim();

            if (string.IsNullOrWhiteSpace(nameToDelete))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            var allCategories = categoryContext.ReadAll();
            var category = allCategories.FirstOrDefault(c => c.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (category == null)
            {
                MessageBox.Show("Category not found.");
                return;
            }

            categoryContext.Delete(category.Id);
            LoadCategories();
            txtCategoryName.Clear();
        }


        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
