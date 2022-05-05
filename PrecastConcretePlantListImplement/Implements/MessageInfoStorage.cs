﻿using PrecastConcretePlantContracts.BindingModels;
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
        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null) return;
            source.MessagesInfo.Add(CreateModel(model, new MessageInfo()));
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
            };
        }
    }
}