using System;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.ViewModels;
using ConcreteGoodsPlantFileImplement.Models;
using PlantBusinessLogic.Enums;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConcreteGoodsPlantFileImplement.Implements
{
    public class MainLogic : IMainLogic
    {
        private readonly FileDataListSingleton source;
        public MainLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetOrders()
        {
            List<OrderViewModel> result = source.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ProductId = rec.ProductId,
                ProductName = source.Products.FirstOrDefault()?.ProductName,
                Count = rec.Count,
                Sum = rec.Sum,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                Status = rec.Status
            })
            .ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                ProductId = model.ProductId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Status != OrderStatus.Принят);
            if (element != null)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Status != OrderStatus.Выполняется);
            if (element != null)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Status != OrderStatus.Готов);
            if (element != null)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = OrderStatus.Оплачен;
        }
    }
}