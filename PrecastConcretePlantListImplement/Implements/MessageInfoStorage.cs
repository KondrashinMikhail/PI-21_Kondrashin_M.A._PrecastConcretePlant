using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton source;
        public MessageInfoStorage() => source = DataListSingleton.GetInstance();
        public List<MessageInfoViewModel> GetFullList()
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var message in source.MessagesInfo) result.Add(CreateModel(message));
            return result;
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null) return null;
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var message in source.MessagesInfo)
            {
                if ((model.ClientId.HasValue && message.ClientId == model.ClientId) ||
                (!model.ClientId.HasValue && message.DateDelivery.Date == model.DateDelivery.Date))
                    result.Add(CreateModel(message));
            }
            if (result.Count > 0) return result;
            return null;
        }
        public MessageInfoViewModel GetElement(MessageInfoBindingModel model)
        {
            if (model == null) return null;
            foreach (var message in source.MessagesInfo)
                if (message.MessageId == model.MessageId) return CreateModel(message);
            return null;
        }
        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null) return;
            source.MessagesInfo.Add(CreateModel(model, new MessageInfo()));
        }
        public void Update(MessageInfoBindingModel model)
        {
            MessageInfo tempMessage = null;
            foreach (var message in source.MessagesInfo)
                if (message.MessageId == model.MessageId)
                {
                    tempMessage = message;
                    break;
                }
            if (tempMessage == null) throw new Exception("Element is not found");
            CreateModel(model, tempMessage);
        }
        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            string clientName = string.Empty;
            foreach (var client in source.Clients)
                if (client.Id == model.ClientId)
                {
                    clientName = client.ClientName;
                    break;
                }
            message.MessageId = model.MessageId;
            message.SenderName = clientName;
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
