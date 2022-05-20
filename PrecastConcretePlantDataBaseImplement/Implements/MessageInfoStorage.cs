using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantDatabaseImplement.Models;
using PrecastConcretePlantDataBaseImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new PrecastConcretePlantDatabase();
            return context.MessagesInfo.Select(CreateModel).ToList();
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null) return null;
            using var context = new PrecastConcretePlantDatabase();
            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue)
                return context.MessagesInfo.Skip((int)model.ToSkip).Take((int)model.ToTake).Select(CreateModel).ToList();
            return context.MessagesInfo
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))
                 .Skip(model.ToSkip ?? 0)
                .Take(model.ToTake ?? context.MessagesInfo.Count())
                .Select(CreateModel)
                .ToList();
        }
        public MessageInfoViewModel GetElement(MessageInfoBindingModel model)
        {
            if (model == null) return null;
            using var context = new PrecastConcretePlantDatabase();
            var message = context.MessagesInfo.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            return message != null ? CreateModel(message) : null;
        }
        public void Insert(MessageInfoBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            MessageInfo element = context.MessagesInfo.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null) throw new Exception("Уже есть письмо с таким идентификатором");
            context.MessagesInfo.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId != null ? model.ClientId : context.Clients.FirstOrDefault(rec => rec.Login == model.FromMailAddress).Id,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Viewed = model.Viewed
            });
            context.SaveChanges();
        }
        public void Update(MessageInfoBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.MessagesInfo.FirstOrDefault(rec => rec.MessageId == model.MessageId);
                if (element == null) throw new Exception("Элемент не найден");
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private MessageInfoViewModel CreateModel(MessageInfo model)
        {
            return new MessageInfoViewModel
            {
                MessageId = model.MessageId,
                SenderName = model.SenderName,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Viewed = model.Viewed,
                Reply = model.Reply
            };
        }
        private static MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.MessageId = model.MessageId;
            message.ClientId = model.ClientId;
            message.Subject = model.Subject;
            message.Body = model.Body;
            message.DateDelivery = model.DateDelivery;
            message.Viewed = model.Viewed;
            message.Reply = model.Reply;
            return message;
        }
    }
}
