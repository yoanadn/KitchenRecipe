namespace KitchenGUI
{
    partial class RecipeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxInstructions;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.NumericUpDown numericUpDownServings;
        private System.Windows.Forms.ComboBox comboBoxCategory;
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
            dataGridView1 = new DataGridView();
            textBoxName = new TextBox();
            textBoxInstructions = new TextBox();
            numericUpDownTime = new NumericUpDown();
            numericUpDownServings = new NumericUpDown();
            comboBoxCategory = new ComboBox();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownServings).BeginInit();
            SuspendLayout();
             
            dataGridView1.BackgroundColor = Color.Moccasin;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(12, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(563, 176);
            dataGridView1.TabIndex = 0;
             
            textBoxName.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxName.Location = new Point(12, 220);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Recipe Title";
            textBoxName.Size = new Size(200, 28);
            textBoxName.TabIndex = 1;
             
            textBoxInstructions.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInstructions.Location = new Point(12, 250);
            textBoxInstructions.Multiline = true;
            textBoxInstructions.Name = "textBoxInstructions";
            textBoxInstructions.PlaceholderText = "Instructions";
            textBoxInstructions.Size = new Size(300, 80);
            textBoxInstructions.TabIndex = 2;
            
            numericUpDownTime.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownTime.Location = new Point(330, 220);
            numericUpDownTime.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDownTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownTime.Name = "numericUpDownTime";
            numericUpDownTime.Size = new Size(120, 28);
            numericUpDownTime.TabIndex = 3;
            numericUpDownTime.Value = new decimal(new int[] { 30, 0, 0, 0 });
             
            numericUpDownServings.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownServings.Location = new Point(330, 250);
            numericUpDownServings.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownServings.Name = "numericUpDownServings";
            numericUpDownServings.Size = new Size(120, 28);
            numericUpDownServings.TabIndex = 4;
            numericUpDownServings.Value = new decimal(new int[] { 2, 0, 0, 0 });
             
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCategory.Location = new Point(330, 280);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(150, 28);
            comboBoxCategory.TabIndex = 5;
             
            btnAdd.BackColor = Color.Bisque;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(500, 220);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 27);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
             
            btnDelete.BackColor = Color.Bisque;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(500, 250);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 27);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
             
            BackColor = Color.Moccasin;
            ClientSize = new Size(634, 361);
            Controls.Add(dataGridView1);
            Controls.Add(textBoxName);
            Controls.Add(textBoxInstructions);
            Controls.Add(numericUpDownTime);
            Controls.Add(numericUpDownServings);
            Controls.Add(comboBoxCategory);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Name = "RecipeForm";
            Text = "Recipe Management";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownServings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
