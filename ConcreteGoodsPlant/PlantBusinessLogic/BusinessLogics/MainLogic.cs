using System;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.Enums;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly object locker = new object();
        private readonly IWarehouseLogic warehouseLogic;
        public MainLogic(IOrderLogic orderLogic, IWarehouseLogic warehouseLogic)
        {           
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                ProductId = model.ProductId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = orderLogic.Read(new OrderBindingModel
                {
                    Id = model.OrderId
                })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Требуются_материалы)
                {
                    throw new Exception("Заказ не в статусе \"Принят\" или \"Требуются материалы\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                var orderModel = new OrderBindingModel
                {
                    Id = order.Id,
                    ProductId = order.ProductId,
                    Count = order.Count,
                    Sum = order.Sum,
                    ClientId = order.ClientId,
                    DateCreate = order.DateCreate
                };
                try
                {
                    warehouseLogic.DeleteFromWarehouse(order.ProductId, order.Count);
                    orderModel.DateImplement = DateTime.Now;
                    orderModel.Status = OrderStatus.Выполняется;
                    orderModel.ImplementerId = model.ImplementerId;
                }
                catch
                {
                    orderModel.Status = OrderStatus.Требуются_материалы;
                }
                orderLogic.CreateOrUpdate(orderModel);
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ProductId = order.ProductId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
               DateImplement = DateTime.Now,
                Status = OrderStatus.Готов
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ProductId = order.ProductId,
                ImplementerId = model.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
        public void FillWarehouse(WarehouseComponentBindingModel model)
        {
            warehouseLogic.AddComponent(model);
        }
    }
}