using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly FileDataListSingleton source;
        public MessageInfoStorage() => source = FileDataListSingleton.GetInstance();
        public List<MessageInfoViewModel> GetFullList()
        {
            return source.MessagesInfo
                .Select(CreateModel)
                .ToList();
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null) return null;
            return source.MessagesInfo
            .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))
            .Select(CreateModel)
            .ToList();
        }
        public MessageInfoViewModel GetElement(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var message = source.MessagesInfo.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            return message != null ? CreateModel(message) : null;
        }
        public void Update(MessageInfoBindingModel model)
        {
            var element = source.MessagesInfo.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Insert(MessageInfoBindingModel model) => source.MessagesInfo.Add(CreateModel(model, new MessageInfo()));
        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.MessageId = model.MessageId;
            message.SenderName = source.Clients.FirstOrDefault(rec => rec.Id == model.ClientId)?.ClientName;
            message.DateDelivery = model.DateDelivery;
            message.Subject = model.Subject;
            message.Body = model.Body;
            message.Viewed = model.Viewed;
            message.Reply = model.Reply;
            return message;
        }
        private MessageInfoViewModel CreateModel(MessageInfo message)
        {
            return new MessageInfoViewModel
            {
                MessageId = message.MessageId,
                SenderName = message.SenderName,
                DateDelivery = message.DateDelivery,
                Subject = message.Subject,
                Body = message.Body,
                Viewed = message.Viewed,
                Reply = message.Reply
            };
        }
    }
}
