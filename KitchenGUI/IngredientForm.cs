using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KitchenGUI
{
    public partial class IngredientForm : Form
    {
        private readonly IngredientContext ingredientContext;
        private readonly RecipeContext recipeContext;

        public IngredientForm(IngredientContext ingredientCtx, RecipeContext recipeCtx)
        {
            InitializeComponent();
            ingredientContext = ingredientCtx;
            recipeContext = recipeCtx;
            LoadIngredients();
            LoadRecipes();
        }

        private void LoadIngredients()
        {
            dgvIngredients.DataSource = ingredientContext.ReadAll(true)
                .OrderBy(i => i.Name)
                .Select(i => new
                {
                    i.Name,
                    i.Quantity,
                    Recipe = i.Recipe != null ? i.Recipe.Title : "None"
                })
                .ToList();
        }

        private void LoadRecipes()
        {
            cbRecipes.DataSource = recipeContext.ReadAll()
                .OrderBy(r => r.Title)
                .ToList();
            cbRecipes.DisplayMember = "Title";
            cbRecipes.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string quantity = txtQuantity.Text.Trim();
            var selectedRecipe = cbRecipes.SelectedItem as Recipe;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(quantity) || selectedRecipe == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var allIngredients = ingredientContext.ReadAll(true);
            bool alreadyExists = allIngredients.Any(i =>
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                i.Quantity.Equals(quantity, StringComparison.OrdinalIgnoreCase) &&
                i.RecipeId == selectedRecipe.Id);

            if (alreadyExists)
            {
                MessageBox.Show("This ingredient already exists for the selected recipe.");
                return;
            }

            var ingredient = new Ingredient
            {
                Name = name,
                Quantity = quantity,
                RecipeId = selectedRecipe.Id
            };

            ingredientContext.Create(ingredient);
            LoadIngredients();
            txtName.Clear();
            txtQuantity.Clear();
            cbRecipes.SelectedIndex = -1;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string quantity = txtQuantity.Text.Trim();
            var selectedRecipe = cbRecipes.SelectedItem as Recipe;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(quantity) || selectedRecipe == null)
            {
                MessageBox.Show("Please fill in Name, Quantity and select a Recipe.");
                return;
            }

            var allIngredients = ingredientContext.ReadAll(true);
            var ingredient = allIngredients.FirstOrDefault(i =>
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                i.Quantity.Equals(quantity, StringComparison.OrdinalIgnoreCase) &&
                i.RecipeId == selectedRecipe.Id);

            if (ingredient == null)
            {
                MessageBox.Show("Ingredient not found.");
                return;
            }

            ingredientContext.Delete(ingredient.Id);
            LoadIngredients(); 
            txtName.Clear();
            txtQuantity.Clear();
            cbRecipes.SelectedIndex = -1;
        }

    }
}
