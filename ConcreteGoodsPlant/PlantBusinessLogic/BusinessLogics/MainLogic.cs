﻿using System;
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
        public MainLogic(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
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
                if (order.Status != OrderStatus.Принят)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    ImplementerId = model.ImplementerId,
                    ProductId = order.ProductId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now,
                    Status = OrderStatus.Выполняется
                });
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            })?[0];
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
            var order = orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            })?[0];
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
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}