namespace KitchenGUI
{
    partial class TagForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.TextBox txtTagName;
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
            dgvTags = new DataGridView();
            txtTagName = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTags).BeginInit();
            SuspendLayout();
             
            dgvTags.BackgroundColor = Color.Moccasin;
            dgvTags.BorderStyle = BorderStyle.None;
            dgvTags.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTags.Location = new Point(12, 12);
            dgvTags.Name = "dgvTags";
            dgvTags.RowHeadersWidth = 51;
            dgvTags.Size = new Size(324, 200);
            dgvTags.TabIndex = 0;
             
            txtTagName.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTagName.Location = new Point(12, 230);
            txtTagName.Name = "txtTagName";
            txtTagName.PlaceholderText = "Enter tag name";
            txtTagName.Size = new Size(165, 28);
            txtTagName.TabIndex = 1;
             
            btnAdd.BackColor = Color.Bisque;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(183, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 27);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
             
            btnDelete.BackColor = Color.Bisque;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(261, 230);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 28);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            
            BackColor = Color.Moccasin;
            ClientSize = new Size(368, 278);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtTagName);
            Controls.Add(dgvTags);
            Name = "TagForm";
            Text = "Manage Tags";
            ((System.ComponentModel.ISupportInitialize)dgvTags).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}