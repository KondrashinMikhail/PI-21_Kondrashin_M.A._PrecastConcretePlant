namespace PrecastConcretePlantView
{
    partial class FormMail
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
            this.labelSender = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.textBoxReply = new System.Windows.Forms.TextBox();
            this.buttonReply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSender
            // 
            this.labelSender.AutoSize = true;
            this.labelSender.Location = new System.Drawing.Point(117, 9);
            this.labelSender.Name = "labelSender";
            this.labelSender.Size = new System.Drawing.Size(55, 20);
            this.labelSender.TabIndex = 0;
            this.labelSender.Text = "Sender";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(117, 39);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(41, 20);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(117, 68);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(58, 20);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Subject";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(117, 100);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(43, 20);
            this.labelBody.TabIndex = 3;
            this.labelBody.Text = "Body";
            // 
            // textBoxReply
            // 
            this.textBoxReply.Location = new System.Drawing.Point(117, 137);
            this.textBoxReply.Name = "textBoxReply";
            this.textBoxReply.Size = new System.Drawing.Size(239, 27);
            this.textBoxReply.TabIndex = 4;
            // 
            // buttonReply
            // 
            this.buttonReply.Location = new System.Drawing.Point(26, 181);
            this.buttonReply.Name = "buttonReply";
            this.buttonReply.Size = new System.Drawing.Size(94, 29);
            this.buttonReply.TabIndex = 5;
            this.buttonReply.Text = "Отправить";
            this.buttonReply.UseVisualStyleBackColor = true;
            this.buttonReply.Click += new System.EventHandler(this.buttonReply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Отправитель:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Дата отправки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Тема:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Текст письма:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ответ:";
            // 
            // FormMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 224);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReply);
            this.Controls.Add(this.textBoxReply);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelSender);
            this.Name = "FormMail";
            this.Text = "Письмо";
            this.Load += new System.EventHandler(this.FormMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelSender;
        private Label labelDate;
        private Label labelSubject;
        private Label labelBody;
        private TextBox textBoxReply;
        private Button buttonReply;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}