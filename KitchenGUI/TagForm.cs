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
    public partial class TagForm : Form
    {
        private readonly TagContext tagContext;

        public TagForm(TagContext context)
        {
            InitializeComponent();
            tagContext = context;
            LoadTags();
        }

        private void LoadTags()
        {
            var tags = tagContext.ReadAll(true)
                .Select((t, index) => new
                {
                    Index = index + 1, 
                    t.Name
                })
                .ToList();

            dgvTags.DataSource = tags;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtTagName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a tag name.");
                return;
            }

            var allTags = tagContext.ReadAll();
            bool alreadyExists = allTags.Any(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
            {
                MessageBox.Show("This tag already exists.");
                return;
            }

            var tag = new Tag { Name = name };
            tagContext.Create(tag);
            LoadTags();
            txtTagName.Clear();
            //this.Close
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string nameToDelete = txtTagName.Text.Trim();

            if (string.IsNullOrWhiteSpace(nameToDelete))
            {
                MessageBox.Show("Please enter a tag name.");
                return;
            }

            var allTags = tagContext.ReadAll();
            var tag = allTags.FirstOrDefault(t => t.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (tag == null)
            {
                MessageBox.Show("Tag not found.");
                return;
            }

            tagContext.Delete(tag.Id);
            LoadTags();
            txtTagName.Clear();
            ///this.Close
        }

    }
}
