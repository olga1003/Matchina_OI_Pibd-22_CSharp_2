using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using ConcreteGoodsPlantDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcreteGoodsPlantDatabaseImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        public List<WarehouseViewModel> GetList()
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                return context.Warehouses
                .ToList()
               .Select(rec => new WarehouseViewModel
               {
                   Id = rec.Id,
                   WarehouseName = rec.WarehouseName,
                   WarehouseComponents = context.WarehouseComponents
                .Include(recWD => recWD.Component)
               .Where(recWD => recWD.WarehouseId == rec.Id).
               Select(x => new WarehouseComponentViewModel
               {
                   Id = x.Id,
                   WarehouseId = x.WarehouseId,
                   ComponentId = x.ComponentId,
                   ComponentName = context.Components.FirstOrDefault(y => y.Id == x.ComponentId).ComponentName,
                   Count = x.Count
               })
               .ToList()
               })
            .ToList();
            }
        }
        public WarehouseViewModel GetElement(int id)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.Id == id);
                if (elem == null)
                {
                    throw new Exception("Элемент не найден");
                }
                else
                {
                    return new WarehouseViewModel
                    {
                        Id = id,
                        WarehouseName = elem.WarehouseName,
                        WarehouseComponents = context.WarehouseComponents
                .Include(recWC => recWC.Component)
               .Where(recWC => recWC.WarehouseId == elem.Id)
                        .Select(x => new WarehouseComponentViewModel
                        {
                            Id = x.Id,
                            WarehouseId = x.WarehouseId,
                            ComponentId = x.ComponentId,
                            ComponentName = context.Components.FirstOrDefault(y => y.Id == x.ComponentId).ComponentName,
                            Count = x.Count
                        }).ToList()
                    };
                }
            }
        }

        public void AddComponent(WarehouseComponentBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                var item = context.WarehouseComponents.FirstOrDefault(x => x.ComponentId == model.ComponentId  && x.WarehouseId == model.WarehouseId);

                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new WarehouseComponent();
                    context.WarehouseComponents.Add(elem);
                    elem.WarehouseId = model.WarehouseId;
                    elem.ComponentId = model.ComponentId;
                    elem.Count = model.Count;
                }
                context.SaveChanges();
            }
        }
        public void UpdElement(WarehouseBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Warehouses.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.WarehouseName = model.WarehouseName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void AddElement(WarehouseBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var warehouse = new Warehouse();
                context.Warehouses.Add(warehouse);
                warehouse.WarehouseName = model.WarehouseName;
                context.SaveChanges();
            }
        }

        public void DelElement(int id)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Warehouses.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void DeleteFromWarehouse(int productId, int count) 
        { 
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var productComponents = context.ProductComponents.Where(x => x.ProductId == productId);
                        if (productComponents.Count() == 0)
                            return;
                        foreach (var elem in productComponents)
                        {
                            int left = elem.Count * count;
                            var warehouseComponents = context.WarehouseComponents.Where(x => x.ComponentId == elem.ComponentId);
                            int available = warehouseComponents.Sum(x => x.Count);
                            if (available < left)
                                throw new Exception("Недостаточно деталей на складе");
                            foreach (var rec in warehouseComponents)
                            {
                                int toRemove = left > rec.Count ? rec.Count : left;
                                rec.Count -= toRemove;
                                left -= toRemove;
                                if (left == 0)
                                    break;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
