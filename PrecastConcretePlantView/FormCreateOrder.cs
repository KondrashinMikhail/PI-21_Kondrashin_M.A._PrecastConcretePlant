using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PrecastConcretePlantView
{
    public partial class FormCreateOrder : Form
    {
        private readonly IReinforcedLogic _logicR;
        private readonly IOrderLogic _logicO;
        private readonly IClientLogic _logicC;
        public FormCreateOrder(IReinforcedLogic logicR, IOrderLogic logicO, IClientLogic logicC)
        {
            InitializeComponent();
            _logicR = logicR;
            _logicO = logicO;
            _logicC = logicC;
            List<ReinforcedViewModel> listReinforceds = _logicR.Read(null);
            List<ClientViewModel> listClients = _logicC.Read(null);
            if (listReinforceds != null && listClients != null)
            {
                comboBoxReinforced.DisplayMember = "ReinforcedName";
                comboBoxReinforced.ValueMember = "Id";
                comboBoxReinforced.DataSource = listReinforceds;
                comboBoxReinforced.SelectedItem = null;

                comboBoxClient.DisplayMember = "ClientName";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = listClients;
                comboBoxClient.SelectedItem = null;
            }
        }
        private void CalcSum()
        {
            if (comboBoxReinforced.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxReinforced.SelectedValue);
                    ReinforcedViewModel reinforced = _logicR.Read(new ReinforcedBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * reinforced?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxCount_TextChanged(object sender, EventArgs e) => CalcSum();
        private void comboBoxReinforced_SelectedIndexChanged(object sender, EventArgs e) => CalcSum();
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxReinforced.SelectedValue == null)
            {
                MessageBox.Show("Выберите пиццу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    ReinforcedId = Convert.ToInt32(comboBoxReinforced.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
