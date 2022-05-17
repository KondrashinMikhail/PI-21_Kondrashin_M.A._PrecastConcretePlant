using PrecastConcretePlantBusinessLogic.BusinessLogics;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantFileImplement;
using System;
using System.Reflection;
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
        private readonly IBackUpLogic _backUpLogic;
        public FormMain(IOrderLogic orderLogic, IImplementerLogic implementerLogic, IReportLogic reportLogic, IWorkProcess workProcess , IBackUpLogic backUpLogic)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
            _implementerLogic = implementerLogic;
            _reportLogic = reportLogic;
            _workProcess = workProcess;
            _backUpLogic = backUpLogic;
        }
        private void FormMain_Load(object sender, EventArgs e) => LoadData();
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(_orderLogic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e) => LoadData();
        private void �����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MethodInfo method = _reportLogic.GetType().GetMethod("SaveComponentsToWordFile");
                method.Invoke(_reportLogic, new object[] { new ReportBindingModel { FileName = dialog.FileName } });
                MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportReinforcedComponents>();
            form.ShowDialog();
        }
        private void �����������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }
        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MethodInfo method = _reportLogic.GetType().GetMethod("SaveWarehousesToWordFile");
                method.Invoke(_reportLogic, new object[] { new ReportBindingModel { FileName = dialog.FileName } });
                MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void �������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportWarehouseComponents>();
            form.ShowDialog();
        }
        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportGeneralOrders>();
            form.ShowDialog();
        }
        private void �����������ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _workProcess.DoWork(_implementerLogic, _orderLogic);
            MessageBox.Show("��������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        private void �����������ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormImplementers>();
            form.ShowDialog();
            LoadData();
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e) => FileDataListSingleton.GetInstance().Save();
        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormMails>();
            form.ShowDialog();
        }
        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpLogic.CreateBackUp(new BackUpSaveBindingModel { FolderName = fbd.SelectedPath });
                        MessageBox.Show("����� ������", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}