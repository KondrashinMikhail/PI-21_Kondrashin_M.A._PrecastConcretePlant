namespace PrecastConcretePlantView
{
    partial class FormWarehouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxWMName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelWMName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComponentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(102, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(240, 27);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxWMName
            // 
            this.textBoxWMName.Location = new System.Drawing.Point(240, 45);
            this.textBoxWMName.Name = "textBoxWMName";
            this.textBoxWMName.Size = new System.Drawing.Size(232, 27);
            this.textBoxWMName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 20);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Название:";
            // 
            // labelWMName
            // 
            this.labelWMName.AutoSize = true;
            this.labelWMName.Location = new System.Drawing.Point(16, 48);
            this.labelWMName.Name = "labelWMName";
            this.labelWMName.Size = new System.Drawing.Size(218, 20);
            this.labelWMName.TabIndex = 3;
            this.labelWMName.Text = "ФИО ответственного за склад:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(322, 392);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(422, 392);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComponentName,
            this.Ide,
            this.ComponentCount});
            this.dataGridView.Location = new System.Drawing.Point(12, 78);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(504, 308);
            this.dataGridView.TabIndex = 6;
            // 
            // ComponentName
            // 
            this.ComponentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ComponentName.HeaderText = "Название компонента";
            this.ComponentName.MinimumWidth = 6;
            this.ComponentName.Name = "ComponentName";
            // 
            // Ide
            // 
            this.Ide.HeaderText = "";
            this.Ide.MinimumWidth = 6;
            this.Ide.Name = "Ide";
            this.Ide.Visible = false;
            this.Ide.Width = 125;
            // 
            // ComponentCount
            // 
            this.ComponentCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ComponentCount.HeaderText = "Количество";
            this.ComponentCount.MinimumWidth = 6;
            this.ComponentCount.Name = "ComponentCount";
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 430);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelWMName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxWMName);
            this.Controls.Add(this.textBoxName);
            this.Name = "FormWarehouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxWMName;
        private Label labelName;
        private Label labelWMName;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ComponentName;
        private DataGridViewTextBoxColumn ComponentCount;
        private DataGridViewTextBoxColumn Ide;
    }
}