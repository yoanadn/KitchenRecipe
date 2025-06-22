using BusinessLayer;
using DataLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KitchenGUI
{
    public partial class RecipeForm : Form
    {
        private readonly RecipeContext recipeContext;
        private readonly CategoryContext categoryContext;
        private readonly IngredientContext ingredientContext;
        private readonly TagContext tagContext;

        public RecipeForm(
            RecipeContext recipeContext,
            CategoryContext categoryContext,
            IngredientContext ingredientContext,
            TagContext tagContext)
        {
            InitializeComponent();
            this.recipeContext = recipeContext;
            this.categoryContext = categoryContext;
            this.ingredientContext = ingredientContext;
            this.tagContext = tagContext;

            this.Load += RecipeForm_Load;
        }

        private void RecipeForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();

            comboBoxCategory.DataSource = categoryContext.ReadAll();
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";
        }

        private void RefreshGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Instructions",
                HeaderText = "Instructions",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PreparationTime",
                HeaderText = "Prep Time"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Servings",
                HeaderText = "Servings"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Category"
            });

            dataGridView1.DataSource = recipeContext.ReadAll(true)
                .OrderBy(r => r.Title)
                .Select(r => new
                {
                    r.Title,
                    r.Instructions,
                    PreparationTime = r.PreparationTime,
                    r.Servings,
                    Category = r.Category?.Name
                })
                .ToList();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            var title = textBoxName.Text.Trim();
            var instructions = textBoxInstructions.Text.Trim();
            var servings = (int)numericUpDownServings.Value;
            var prepTime = (int)numericUpDownTime.Value;
            var category = comboBoxCategory.SelectedItem as Category;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(instructions) || category == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

           
            var allRecipes = recipeContext.ReadAll(true);
            bool alreadyExists = allRecipes.Any(r =>
                r.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                r.Instructions.Equals(instructions, StringComparison.OrdinalIgnoreCase) &&
                r.Servings == servings &&
                r.PreparationTime == prepTime &&
                r.CategoryId == category.Id);

            if (alreadyExists)
            {
                MessageBox.Show("This recipe already exists.");
                return;
            }

            var recipe = new Recipe
            {
                Title = title,
                Instructions = instructions,
                Servings = servings,
                PreparationTime = prepTime,
                CategoryId = category.Id,
                Category = category
            };

            recipeContext.Create(recipe);
            RefreshGrid();

            textBoxName.Clear();
            textBoxInstructions.Clear();
            numericUpDownServings.Value = 1;
            numericUpDownTime.Value = 1;
            comboBoxCategory.SelectedIndex = -1;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            var title = textBoxName.Text.Trim();
            var instructions = textBoxInstructions.Text.Trim();
            var servings = (int)numericUpDownServings.Value;
            var prepTime = (int)numericUpDownTime.Value;
            var category = comboBoxCategory.SelectedItem as Category;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(instructions) || category == null)
            {
                MessageBox.Show("Please fill in all fields to delete a recipe.");
                return;
            }

            var allRecipes = recipeContext.ReadAll(true);
            var recipe = allRecipes.FirstOrDefault(r =>
                r.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                r.Instructions.Equals(instructions, StringComparison.OrdinalIgnoreCase) &&
                r.Servings == servings &&
                r.PreparationTime == prepTime &&
                r.CategoryId == category.Id);

            if (recipe == null)
            {
                MessageBox.Show("No matching recipe found.");
                return;
            }

            recipeContext.Delete(recipe.Id);
            RefreshGrid();

            textBoxName.Clear();
            textBoxInstructions.Clear();
            numericUpDownServings.Value = 1;
            numericUpDownTime.Value = 1;
            comboBoxCategory.SelectedIndex = -1;
        }

    }
}
