namespace PrecastConcretePlantView
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
            this.toolStripMenuItemWarehouses = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddComponentsToWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоЖБИToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКонкретныхЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыНаСкладахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.общийСписокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemReferences,
            this.toolStripMenuItemAddComponentsToWarehouse,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1265, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemReferences
            // 
            this.toolStripMenuItemReferences.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemComponents,
            this.toolStripMenuItemReinforceds,
            this.toolStripMenuItemWarehouses,
            this.клиентыToolStripMenuItem});
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
            // toolStripMenuItemWarehouses
            // 
            this.toolStripMenuItemWarehouses.Name = "toolStripMenuItemWarehouses";
            this.toolStripMenuItemWarehouses.Size = new System.Drawing.Size(275, 26);
            this.toolStripMenuItemWarehouses.Text = "Склады";
            this.toolStripMenuItemWarehouses.Click += new System.EventHandler(this.toolStripMenuItemWarehouses_Click);
            // 
            // toolStripMenuItemAddComponentsToWarehouse
            // 
            this.toolStripMenuItemAddComponentsToWarehouse.Name = "toolStripMenuItemAddComponentsToWarehouse";
            this.toolStripMenuItemAddComponentsToWarehouse.Size = new System.Drawing.Size(162, 24);
            this.toolStripMenuItemAddComponentsToWarehouse.Text = "Пополнение склада";
            this.toolStripMenuItemAddComponentsToWarehouse.Click += new System.EventHandler(this.toolStripMenuItemAddComponentsToWarehouse_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомпонентовToolStripMenuItem,
            this.компонентыПоЖБИToolStripMenuItem,
            this.списокКонкретныхЗаказовToolStripMenuItem,
            this.списокСкладовToolStripMenuItem,
            this.компонентыНаСкладахToolStripMenuItem,
            this.общийСписокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            this.списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            this.списокКомпонентовToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.списокКомпонентовToolStripMenuItem.Text = "Список компонентов";
            this.списокКомпонентовToolStripMenuItem.Click += new System.EventHandler(this.списокКомпонентовToolStripMenuItem_Click);
            // 
            // компонентыПоЖБИToolStripMenuItem
            // 
            this.компонентыПоЖБИToolStripMenuItem.Name = "компонентыПоЖБИToolStripMenuItem";
            this.компонентыПоЖБИToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.компонентыПоЖБИToolStripMenuItem.Text = "Компоненты по ЖБИ";
            this.компонентыПоЖБИToolStripMenuItem.Click += new System.EventHandler(this.компонентыПоЖБИToolStripMenuItem_Click);
            // 
            // списокКонкретныхЗаказовToolStripMenuItem
            // 
            this.списокКонкретныхЗаказовToolStripMenuItem.Name = "списокКонкретныхЗаказовToolStripMenuItem";
            this.списокКонкретныхЗаказовToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.списокКонкретныхЗаказовToolStripMenuItem.Text = "Список конкретных заказов";
            this.списокКонкретныхЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокКонкретныхЗаказовToolStripMenuItem_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // компонентыНаСкладахToolStripMenuItem
            // 
            this.компонентыНаСкладахToolStripMenuItem.Name = "компонентыНаСкладахToolStripMenuItem";
            this.компонентыНаСкладахToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.компонентыНаСкладахToolStripMenuItem.Text = "Компоненты на складах";
            this.компонентыНаСкладахToolStripMenuItem.Click += new System.EventHandler(this.компонентыНаСкладахToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1058, 407);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(1076, 52);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(177, 29);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(1076, 87);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(177, 29);
            this.buttonTakeOrderInWork.TabIndex = 3;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(1076, 122);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(177, 29);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(1076, 157);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(177, 29);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(1076, 192);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(177, 29);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // общийСписокЗаказовToolStripMenuItem
            // 
            this.общийСписокЗаказовToolStripMenuItem.Name = "общийСписокЗаказовToolStripMenuItem";
            this.общийСписокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.общийСписокЗаказовToolStripMenuItem.Text = "Общий список заказов";
            this.общийСписокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.общийСписокЗаказовToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 450);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Завод ЖБИ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
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
        private Button buttonTakeOrderInWork;
        private Button buttonOrderReady;
        private Button buttonIssuedOrder;
        private Button buttonRefresh;
        private ToolStripMenuItem toolStripMenuItemWarehouses;
        private ToolStripMenuItem toolStripMenuItemAddComponentsToWarehouse;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private ToolStripMenuItem компонентыПоЖБИToolStripMenuItem;
        private ToolStripMenuItem списокКонкретныхЗаказовToolStripMenuItem;
        private ToolStripMenuItem списокСкладовToolStripMenuItem;
        private ToolStripMenuItem компонентыНаСкладахToolStripMenuItem;
        private ToolStripMenuItem общийСписокЗаказовToolStripMenuItem;
        private ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private ToolStripMenuItem клиентыToolStripMenuItem;
    }
}