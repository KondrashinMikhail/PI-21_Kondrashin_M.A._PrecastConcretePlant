﻿namespace PrecastConcretePlantView
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemReferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemComponents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReinforceds = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоЖБИToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemReferences,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.письмаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1384, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemReferences
            // 
            this.toolStripMenuItemReferences.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemComponents,
            this.toolStripMenuItemReinforceds,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.toolStripMenuItemReferences.Name = "toolStripMenuItemReferences";
            this.toolStripMenuItemReferences.Size = new System.Drawing.Size(117, 24);
            this.toolStripMenuItemReferences.Text = "Справочники";
            // 
            // toolStripMenuItemComponents
            // 
            this.toolStripMenuItemComponents.Name = "toolStripMenuItemComponents";
            this.toolStripMenuItemComponents.Size = new System.Drawing.Size(275, 26);
            this.toolStripMenuItemComponents.Text = "Компоненты";
            this.toolStripMenuItemComponents.Click += new System.EventHandler(this.toolStripMenuItemComponents_Click);
            // 
            // toolStripMenuItemReinforceds
            // 
            this.toolStripMenuItemReinforceds.Name = "toolStripMenuItemReinforceds";
            this.toolStripMenuItemReinforceds.Size = new System.Drawing.Size(275, 26);
            this.toolStripMenuItemReinforceds.Text = "Железобетонные изделия";
            this.toolStripMenuItemReinforceds.Click += new System.EventHandler(this.toolStripMenuItemReinforceds_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомпонентовToolStripMenuItem,
            this.компонентыПоЖБИToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            this.списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            this.списокКомпонентовToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.списокКомпонентовToolStripMenuItem.Text = "Список компонентов";
            this.списокКомпонентовToolStripMenuItem.Click += new System.EventHandler(this.списокКомпонентовToolStripMenuItem_Click);
            // 
            // компонентыПоЖБИToolStripMenuItem
            // 
            this.компонентыПоЖБИToolStripMenuItem.Name = "компонентыПоЖБИToolStripMenuItem";
            this.компонентыПоЖБИToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.компонентыПоЖБИToolStripMenuItem.Text = "Компоненты по ЖБИ";
            this.компонентыПоЖБИToolStripMenuItem.Click += new System.EventHandler(this.компонентыПоЖБИToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1177, 407);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(1195, 52);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(177, 29);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(1195, 87);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(177, 29);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(1195, 122);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(177, 29);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.письмаToolStripMenuItem.Text = "Письма";
            this.письмаToolStripMenuItem.Click += new System.EventHandler(this.письмаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 450);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Завод ЖБИ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItemReferences;
        private ToolStripMenuItem toolStripMenuItemComponents;
        private ToolStripMenuItem toolStripMenuItemReinforceds;
        private DataGridView dataGridView;
        private Button buttonCreateOrder;
        private Button buttonIssuedOrder;
        private Button buttonRefresh;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private ToolStripMenuItem компонентыПоЖБИToolStripMenuItem;
        private ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private ToolStripMenuItem клиентыToolStripMenuItem;
        private ToolStripMenuItem исполнителиToolStripMenuItem;
        private ToolStripMenuItem запускРаботToolStripMenuItem;
        private ToolStripMenuItem письмаToolStripMenuItem;
    }
}