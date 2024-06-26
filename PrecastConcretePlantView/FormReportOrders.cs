﻿using Microsoft.Reporting.WinForms;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrecastConcretePlantView
{
    public partial class FormReportOrders : Form
    {
        private readonly ReportViewer reportViewer;
        private readonly IReportLogic _logic;
        public FormReportOrders(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            reportViewer = new ReportViewer { Dock = DockStyle.Fill };
            reportViewer.LocalReport.LoadReportDefinition(new FileStream("C://Users//user//Source//Repos//PI-21_Kondrashin_M.A._PrecastConcretePlant//PrecastConcretePlantView//Report.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            panel.Dock = DockStyle.Top;
            Controls.Add(panel);
        }
        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                MethodInfo method = _logic.GetType().GetMethod("GetOrders");
                var dataSource = method.Invoke(_logic, new object[] { new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                } });
                var source = new ReportDataSource("DataSetOrders", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                var parameters = new[] { new ReportParameter("ReportParameterPeriod",
                    "c " + dateTimePickerFrom.Value.ToShortDateString() +
                    " по " + dateTimePickerTo.Value.ToShortDateString()) };
                reportViewer.LocalReport.SetParameters(parameters);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MethodInfo method = _logic.GetType().GetMethod("SaveOrdersToPdfFile");
                    method.Invoke(_logic, new object[] { new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    }});
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