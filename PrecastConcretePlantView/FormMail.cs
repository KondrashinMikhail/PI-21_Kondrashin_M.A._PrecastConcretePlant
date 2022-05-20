using PrecastConcretePlantBusinessLogic.MailWorker;
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
    public partial class FormMail : Form
    {
        public string MessageId
        {
            set { messageId = value; }
        }
        private readonly IMessageInfoLogic _messageLogic;

        private readonly IClientLogic _clientLogic;

        private readonly AbstractMailWorker _mailWorker;
        private string messageId;
        public FormMail(IMessageInfoLogic messageLogic, IClientLogic clientLogic, AbstractMailWorker mailWorker)
        {
            InitializeComponent();
            _clientLogic = clientLogic;
            _messageLogic = messageLogic;
            _mailWorker = mailWorker;
        }
        private void FormMail_Load(object sender, EventArgs e)
        {
            if (messageId != null)
            {
                try
                {
                    var view = _messageLogic.Read(new MessageInfoBindingModel { MessageId = messageId })?[0];
                    if (view != null)
                    {
                        if (!view.Viewed)
                        {
                            _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                            {
                                ClientId = _clientLogic.Read(new ClientBindingModel { Login = view.SenderName })?[0].Id,
                                MessageId = messageId,
                                FromMailAddress = view.SenderName,
                                Subject = view.Subject,
                                Body = view.Body,
                                DateDelivery = view.DateDelivery,
                                Viewed = true,
                                Reply = view.Reply
                            });
                        }
                        labelBody.Text = view.Body;
                        labelSender.Text = view.SenderName;
                        labelSubject.Text = view.Subject;
                        labelDate.Text = view.DateDelivery.ToString();
                        textBoxReply.Text = view.Reply;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonReply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReply.Text))
            {
                MessageBox.Show("Введите текст ответа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _mailWorker.MailSendAsync(new MailSendInfoBindingModel
                {
                    MailAddress = labelSender.Text,
                    Subject = "Re: " + labelSubject.Text,
                    Text = textBoxReply.Text
                });
                _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                {
                    ClientId = _clientLogic.Read(new ClientBindingModel { Login = labelSender.Text })?[0].Id,
                    MessageId = messageId,
                    FromMailAddress = labelSender.Text,
                    Subject = labelSubject.Text,
                    Body = labelBody.Text,
                    DateDelivery = DateTime.Parse(labelDate.Text),
                    Viewed = true,
                    Reply = textBoxReply.Text
                });
                MessageBox.Show("Ответ отправлен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
