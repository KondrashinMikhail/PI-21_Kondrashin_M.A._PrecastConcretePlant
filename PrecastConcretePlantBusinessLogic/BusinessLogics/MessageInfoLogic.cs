using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly IMessageInfoStorage _messageInfoStorage;
        public MessageInfoLogic(IMessageInfoStorage messsageInfoStorage) => _messageInfoStorage = messsageInfoStorage;
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            if (model == null) return _messageInfoStorage.GetFullList();
            return _messageInfoStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(MessageInfoBindingModel model) => _messageInfoStorage.Insert(model);
    }
}
