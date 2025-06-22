namespace KitchenGUI
{
    partial class CategoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvCategories = new DataGridView();
            txtCategoryName = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            
            dgvCategories.BackgroundColor = Color.Moccasin;
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Location = new Point(12, 12);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.RowHeadersWidth = 51;
            dgvCategories.Size = new Size(326, 198);
            dgvCategories.TabIndex = 0;
            
            txtCategoryName.BackColor = SystemColors.ButtonHighlight;
            txtCategoryName.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCategoryName.Location = new Point(12, 230);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "Category Name";
            txtCategoryName.Size = new Size(165, 28);
            txtCategoryName.TabIndex = 1;
             
            btnAdd.BackColor = Color.Bisque;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(190, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
             
            btnDelete.BackColor = Color.Bisque;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(266, 230);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(72, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
             
            BackColor = Color.Moccasin;
            ClientSize = new Size(469, 305);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtCategoryName);
            Controls.Add(dgvCategories);
            Name = "CategoryForm";
            Text = "Category Management";
            Load += CategoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}