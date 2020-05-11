using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}
