using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PrecastConcretePlantView
{
    public partial class FormReinforced : Form
    {
        public int Id { set { iD = value; } }
        private int? iD;
        private readonly IReinforcedLogic _logic;
        private Dictionary<int, (string, int)> reinforcedComponents;
        public FormReinforced(IReinforcedLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormReinforced_Load(object sender, EventArgs e)
        {
            if (iD.HasValue)
            {
                try
                {
                    ImplemenerViewModel view = _logic.Read(new ReinforcedBindingModel { Id = iD.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.ReinforcedName;
                        textBoxPrice.Text = view.Price.ToString();
                        reinforcedComponents = view.ReinforcedComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else reinforcedComponents = new Dictionary<int, (string, int)>();
        }
        private void LoadData()
        {
            try
            {
                if (reinforcedComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in reinforcedComponents) dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReinforcedComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (reinforcedComponents.ContainsKey(form.Id)) reinforcedComponents[form.Id] = (form.ComponentName, form.Count);
                else reinforcedComponents.Add(form.Id, (form.ComponentName, form.Count));
                LoadData();
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormReinforcedComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = reinforcedComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    reinforcedComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        reinforcedComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e) => LoadData();
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (reinforcedComponents == null || reinforcedComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ReinforcedBindingModel
                {
                    Id = iD,
                    ReinforcedName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    ReinforcedComponents = reinforcedComponents
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
