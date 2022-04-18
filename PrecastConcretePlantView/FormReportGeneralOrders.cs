using Microsoft.Reporting.WinForms;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrecastConcretePlantView
{
    public partial class FormReportGeneralOrders : Form
    {
        private readonly ReportViewer reportViewer;
        private readonly IReportLogic _logic;
        public FormReportGeneralOrders(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            reportViewer = new ReportViewer { Dock = DockStyle.Fill };
            reportViewer.LocalReport.LoadReportDefinition(new FileStream("C://Users//user//Source//Repos//PI-21_Kondrashin_M.A._PrecastConcretePlant//PrecastConcretePlantView//GeneralReport.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            panel.Dock = DockStyle.Top;
            Controls.Add(panel);
        }
        private void FormReportGeneralOrders_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = _logic.GetGeneralOrders(new ReportBindingModel { });
                var source = new ReportDataSource("DataSetGeneralOrders", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveGeneralOrdersToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
