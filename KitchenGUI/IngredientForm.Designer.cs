namespace KitchenGUI
{
    partial class IngredientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cbRecipes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvIngredients = new DataGridView();
            txtName = new TextBox();
            txtQuantity = new TextBox();
            cbRecipes = new ComboBox();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).BeginInit();
            SuspendLayout();
            
            dgvIngredients.BackgroundColor = Color.Moccasin;
            dgvIngredients.BorderStyle = BorderStyle.None;
            dgvIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredients.Location = new Point(12, 12);
            dgvIngredients.Name = "dgvIngredients";
            dgvIngredients.RowHeadersWidth = 51;
            dgvIngredients.Size = new Size(429, 200);
            dgvIngredients.TabIndex = 0;
            
            txtName.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(12, 230);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(150, 28);
            txtName.TabIndex = 1;
            
            txtQuantity.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuantity.Location = new Point(12, 264);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PlaceholderText = "Quantity";
            txtQuantity.Size = new Size(150, 28);
            txtQuantity.TabIndex = 2;
            
            cbRecipes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRecipes.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbRecipes.Location = new Point(177, 230);
            cbRecipes.Name = "cbRecipes";
            cbRecipes.Size = new Size(150, 28);
            cbRecipes.TabIndex = 3;
            
            btnAdd.BackColor = Color.Bisque;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(366, 229);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 28);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            
            btnDelete.BackColor = Color.Bisque;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(366, 263);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 27);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            
            BackColor = Color.Moccasin;
            ClientSize = new Size(483, 311);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(cbRecipes);
            Controls.Add(txtQuantity);
            Controls.Add(txtName);
            Controls.Add(dgvIngredients);
            Name = "IngredientForm";
            Text = "Ingredient Management";
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}