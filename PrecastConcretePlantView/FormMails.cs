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
using Unity;

namespace PrecastConcretePlantView
{
    public partial class FormMails : Form
    {
        private readonly IMessageInfoLogic _logic;
        private bool hasNext = false;
        private readonly int mailsNum = 5;
        private int curPage = 0;
        public FormMails(IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void LoadData()
        {
            var list = _logic.Read(new MessageInfoBindingModel
            {
                ToSkip = curPage * mailsNum,
                ToTake = mailsNum + 1
            });
            hasNext = !(list.Count() <= mailsNum);
            if (hasNext) buttonNext.Enabled = true;
            else buttonNext.Enabled = false;
            if (list != null) dataGridView.DataSource = list.Take(mailsNum).ToList();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                curPage++;
                labelPage.Text = (curPage + 1).ToString();
                buttonPrevious.Enabled = true;
                LoadData();
            }
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if ((curPage - 1) >= 0)
            {
                curPage--;
                labelPage.Text = (curPage + 1).ToString();
                buttonNext.Enabled = true;
                if (curPage == 0) buttonPrevious.Enabled = false;
                LoadData();
            }
        }
        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
            labelPage.Text = "1";
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormMail>();
                form.MessageId = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                form.ShowDialog();
                LoadData();
            }
        }
    }
}
