using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public interface IMainLogic
    {
        List<OrderViewModel> GetOrders();

        void CreateOrder(OrderBindingModel model);

        void TakeOrderInWork(OrderBindingModel model);

        void FinishOrder(OrderBindingModel model);

        void PayOrder(OrderBindingModel model);
    }
}
