using PrecastConcretePlantBusinessLogic.BusinessLogics;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantFileImplement;
using System;
using System.Windows.Forms;
using Unity;

namespace PrecastConcretePlantView
{
    public partial class FormMain : Form
    {
        private readonly IOrderLogic _orderLogic;
        private readonly IImplementerLogic _implementerLogic;
        private readonly IReportLogic _reportLogic;
        private readonly IWorkProcess _workProcess;
        public FormMain(IOrderLogic orderLogic, IImplementerLogic implementerLogic, IReportLogic reportLogic, IWorkProcess workProcess)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
            _implementerLogic = implementerLogic;
            _reportLogic = reportLogic;
            _workProcess = workProcess;
        }
        private void FormMain_Load(object sender, EventArgs e) => LoadData();
        private void LoadData()
        {
            try
            {
                var list = _orderLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItemComponents_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormComponents>();
            form.ShowDialog();
        }
        private void toolStripMenuItemReinforceds_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReinforceds>();
            form.ShowDialog();
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClients>();
            form.ShowDialog();
        }
        private void toolStripMenuItemWarehouses_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouses>();
            form.ShowDialog();
        }
        private void toolStripMenuItemAddComponentsToWarehouse_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouseComponent>();
            form.ShowDialog();
        }
        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
        private void buttonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                int implementerId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[3].Value);
                try
                {
                    _orderLogic.DeliveryOrder(new ChangeStatusBindingModel 
                    { 
                        OrderId = id,
                        ImplementerId = implementerId
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e) => LoadData();
        private void списокКомпонентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveComponentsToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void компонентыПоЖБИToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportReinforcedComponents>();
            form.ShowDialog();
        }
        private void списокКонкретныхЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }
        private void списокСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveWarehousesToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void компонентыНаСкладахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportWarehouseComponents>();
            form.ShowDialog();
        }
        private void общийСписокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportGeneralOrders>();
            form.ShowDialog();
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e) => FileDataListSingleton.GetInstance().Save();

        private void запускРаботToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
             _workProcess.DoWork(_implementerLogic, _orderLogic);
            MessageBox.Show("Запущено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void исполнителиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormImplementers>();
            form.ShowDialog();
            LoadData();
        }
    }
}