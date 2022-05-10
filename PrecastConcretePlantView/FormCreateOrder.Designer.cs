namespace PrecastConcretePlantView
{
    partial class FormCreateOrder
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
            this.labelReinforced = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.comboBoxReinforced = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelReinforced
            // 
            this.labelReinforced.AutoSize = true;
            this.labelReinforced.Location = new System.Drawing.Point(12, 14);
            this.labelReinforced.Name = "labelReinforced";
            this.labelReinforced.Size = new System.Drawing.Size(193, 20);
            this.labelReinforced.TabIndex = 0;
            this.labelReinforced.Text = "Железобетонное изделие:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 43);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(93, 20);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(12, 78);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(58, 20);
            this.labelSum.TabIndex = 2;
            this.labelSum.Text = "Сумма:";
            // 
            // comboBoxReinforced
            // 
            this.comboBoxReinforced.FormattingEnabled = true;
            this.comboBoxReinforced.Location = new System.Drawing.Point(211, 11);
            this.comboBoxReinforced.Name = "comboBoxReinforced";
            this.comboBoxReinforced.Size = new System.Drawing.Size(223, 28);
            this.comboBoxReinforced.TabIndex = 3;
            this.comboBoxReinforced.SelectedIndexChanged += new System.EventHandler(this.comboBoxReinforced_SelectedIndexChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(211, 45);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(223, 27);
            this.textBoxCount.TabIndex = 4;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Enabled = false;
            this.textBoxSum.Location = new System.Drawing.Point(211, 78);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(223, 27);
            this.textBoxSum.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(239, 163);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(340, 163);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(211, 111);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(223, 28);
            this.comboBoxClient.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Выберите клиента:";
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 204);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxReinforced);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelReinforced);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelReinforced;
        private Label labelCount;
        private Label labelSum;
        private ComboBox comboBoxReinforced;
        private TextBox textBoxCount;
        private TextBox textBoxSum;
        private Button buttonSave;
        private Button buttonCancel;
        private ComboBox comboBoxClient;
        private Label label1;
    }
}