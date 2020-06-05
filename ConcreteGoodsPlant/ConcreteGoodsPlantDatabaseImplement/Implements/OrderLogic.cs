using System;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.ViewModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ConcreteGoodsPlantDatabaseImplement.Models;
using System.Linq;

namespace ConcreteGoodsPlantDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order { };
                    context.Orders.Add(element);
                }
                element.ProductId = model.ProductId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                        model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                return context.Orders
                .Include(rec => rec.Product)
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ProductId = rec.ProductId,
                    ProductName = rec.Product.ProductName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                })
            .ToList();
            }
        }
    }
}

