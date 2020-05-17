﻿using System;
using System.Collections.Generic;
using System.Text;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.ViewModels;
using ConcreteGoodsPlantFileImplement.Models;
using System.Linq;

namespace ConcreteGoodsPlantFileImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly FileDataListSingleton source;
        public WarehouseLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<WarehouseViewModel> GetList()
        {
            return source.Warehouses.Select(rec => new WarehouseViewModel
            {
                Id = rec.Id,
                WarehouseName = rec.WarehouseName,
                WarehouseComponents = source.WarehouseComponents.Where(z => z.WarehouseId == rec.Id)
                .Select(x => new WarehouseComponentViewModel
                {
                    Id = x.Id,
                    WarehouseId = x.WarehouseId,
                    ComponentId = x.ComponentId,
                    ComponentName = source.Components.FirstOrDefault(y => y.Id == x.ComponentId)?.ComponentName,
                    Count = x.Count
                }).ToList()
            }).ToList();
        }
        public WarehouseViewModel GetElement(int id)
        {
            var elem = source.Warehouses.FirstOrDefault(x => x.Id == id);
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
                    WarehouseComponents = source.WarehouseComponents.Where(z => z.WarehouseId == elem.Id)
                    .Select(x => new WarehouseComponentViewModel
                    {
                        Id = x.Id,
                        WarehouseId = x.WarehouseId,
                        ComponentId = x.ComponentId,
                        ComponentName = source.Components.FirstOrDefault(y => y.Id == x.ComponentId)?.ComponentName,
                        Count = x.Count
                    }).ToList()
                };
            }
        }
        public void AddElement(WarehouseBindingModel model)
        {

            var elem = source.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;
            source.Warehouses.Add(new Warehouse
            {
                Id = maxId + 1,
                WarehouseName = model.WarehouseName
            });
        }
        public void UpdElement(WarehouseBindingModel model)
        {
            var elem = source.Warehouses.FirstOrDefault(x =>
                x.WarehouseName == model.WarehouseName && x.Id != model.Id);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            var elemToUpdate = source.Warehouses.FirstOrDefault(x => x.Id == model.Id);
            if (elemToUpdate != null)
            {
                elemToUpdate.WarehouseName = model.WarehouseName;
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void DelElement(int id)
        {
            var elem = source.Warehouses.FirstOrDefault(x => x.Id == id);
            if (elem != null)
                source.Warehouses.Remove(elem);
            else
                throw new Exception("Элемент не найден");
        }
        public void AddComponent(WarehouseComponentBindingModel model)
        {
            Warehouse warehouse = source.Warehouses.FirstOrDefault(rec => rec.Id == model.WarehouseId);

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            Component component = source.Components.FirstOrDefault(rec => rec.Id == model.ComponentId);

            if (component == null)
            {
                throw new Exception("Компонент не найден");
            }

            WarehouseComponent element = source.WarehouseComponents
                        .FirstOrDefault(rec => rec.WarehouseId == model.WarehouseId && rec.ComponentId == model.ComponentId);

            if (element != null)
            {
                element.Count += model.Count;
                return;
            }

            source.WarehouseComponents.Add(new WarehouseComponent
            {
                Id = source.WarehouseComponents.Count > 0 ? source.WarehouseComponents.Max(rec => rec.Id) + 1 : 0,
                WarehouseId = model.WarehouseId,
                ComponentId = model.ComponentId,
                Count = model.Count
            });
        }
        public bool CheckAvailable(int ProductId, int ProductsCount)
        {
            bool result = true;
            var ProductComponents = source.ProductComponents
            .Where(x => x.ProductId == ProductId);
            if (ProductComponents.Count() == 0)
                return false;
            foreach (var elem in ProductComponents)
            {
                int count = 0;
                var warehouseComponents = source.WarehouseComponents.FindAll(x => x.ComponentId == elem.ComponentId);
                count = warehouseComponents.Sum(x => x.Count);
                if (count < elem.Count * ProductsCount)
                    return false;
            }
            return result;
        }

        public void DeleteFromWarehouse(int ProductId, int ProductsCount)
        {
            var ProductComponents = source.ProductComponents.Where(x => x.ProductId == ProductId);
            if (ProductComponents.Count() == 0) return;
            foreach (var elem in ProductComponents)
            {
                int left = elem.Count * ProductsCount;
                var warehouseComponents = source.WarehouseComponents.FindAll(x => x.ComponentId == elem.ComponentId);
                foreach (var rec in warehouseComponents)
                {
                    int toRemove = left > rec.Count ? rec.Count : left;
                    rec.Count -= toRemove;
                    left -= toRemove;
                    if (left == 0) break;
                }
            }
            return;
        }
    }
}