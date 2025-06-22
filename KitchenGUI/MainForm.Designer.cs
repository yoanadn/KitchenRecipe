namespace KitchenGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnRecipes = new Button();
            btnCategories = new Button();
            btnIngredients = new Button();
            btnTags = new Button();
            btnExit = new Button();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            
            btnRecipes.BackColor = Color.Bisque;
            btnRecipes.FlatStyle = FlatStyle.Flat;
            btnRecipes.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRecipes.Location = new Point(264, 133);
            btnRecipes.Name = "btnRecipes";
            btnRecipes.Size = new Size(200, 40);
            btnRecipes.TabIndex = 0;
            btnRecipes.Text = "Manage Recipes";
            btnRecipes.UseVisualStyleBackColor = false;
            btnRecipes.Click += btnRecipes_Click;
             
            btnCategories.BackColor = Color.Bisque;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCategories.Location = new Point(264, 183);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(200, 40);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Manage Categories";
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += btnCategories_Click;
            
            btnIngredients.BackColor = Color.Bisque;
            btnIngredients.FlatStyle = FlatStyle.Flat;
            btnIngredients.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngredients.Location = new Point(264, 233);
            btnIngredients.Name = "btnIngredients";
            btnIngredients.Size = new Size(200, 40);
            btnIngredients.TabIndex = 2;
            btnIngredients.Text = "Manage Ingredients";
            btnIngredients.UseVisualStyleBackColor = false;
            btnIngredients.Click += btnIngredients_Click;
            
            btnTags.BackColor = Color.Bisque;
            btnTags.FlatStyle = FlatStyle.Flat;
            btnTags.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTags.Location = new Point(264, 283);
            btnTags.Name = "btnTags";
            btnTags.Size = new Size(200, 40);
            btnTags.TabIndex = 3;
            btnTags.Text = "Manage Tags";
            btnTags.UseVisualStyleBackColor = false;
            btnTags.Click += btnTags_Click;
            
            btnExit.BackColor = Color.BlanchedAlmond;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(623, 340);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(79, 41);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Calligraphy", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 51);
            label1.Name = "label1";
            label1.Size = new Size(609, 39);
            label1.TabIndex = 5;
            label1.Text = "Welcome to Kitchen Recipe Manager";
            label1.TextAlign = ContentAlignment.TopCenter;
            
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(7, 214);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(251, 176);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            
            BackColor = Color.Moccasin;
            ClientSize = new Size(724, 402);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnTags);
            Controls.Add(btnIngredients);
            Controls.Add(btnCategories);
            Controls.Add(btnRecipes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Kitchen Manager";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnRecipes;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnIngredients;
        private System.Windows.Forms.Button btnTags;
        private System.Windows.Forms.Button btnExit;
        private Label label1;
        private PictureBox pictureBox2;
    }
}