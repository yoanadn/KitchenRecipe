using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace KitchenGUI
{
    public partial class MainForm : Form
    {
        private readonly RecipeContext recipeContext;
        private readonly CategoryContext categoryContext;
        private readonly IngredientContext ingredientContext;
        private readonly TagContext tagContext;

        public MainForm(RecipeContext recipeContext, CategoryContext categoryContext, IngredientContext ingredientContext, TagContext tagContext)
        {
            InitializeComponent();

            this.recipeContext = recipeContext;
            this.categoryContext = categoryContext;
            this.ingredientContext = ingredientContext;
            this.tagContext = tagContext;

            this.Text = "Kitchen Manager";
            this.BackColor = System.Drawing.Color.LemonChiffon;
        }


        private void btnRecipes_Click(object sender, EventArgs e)
        {
            var form = new RecipeForm(recipeContext, categoryContext, ingredientContext, tagContext);
            form.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            var form = new CategoryForm(categoryContext);
            form.ShowDialog();
        }

        private void btnIngredients_Click(object sender, EventArgs e)
        {
            var form = new IngredientForm(ingredientContext, recipeContext);
            form.ShowDialog();
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            var form = new TagForm(tagContext);
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
