﻿using ConcreteGoodsPlantListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConcreteGoodsPlantListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Product> Products { get; set; }

        public List<ProductComponent> ProductComponents { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public List<WarehouseComponent> WarehouseComponents { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductComponents = new List<ProductComponent>();
            Warehouses = new List<Warehouse>();
            WarehouseComponents = new List<WarehouseComponent>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}