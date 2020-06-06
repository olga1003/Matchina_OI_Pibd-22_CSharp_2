using ConcreteGoodsPlantFileImplement.Models;
using System;
using PlantBusinessLogic.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ConcreteGoodsPlantFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string ProductFileName = "Product.xml";
        private readonly string ProductComponentFileName = "ProductComponent.xml";
        private readonly string WarehouseFileName = "Warehouse.xml";
        private readonly string WarehouseComponentFileName = "WarehouseComponent.xml";

        private readonly string ClientFileName = "Client.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductComponent> ProductComponents { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<WarehouseComponent> WarehouseComponents { get; set; }

        public List<Client> Clients { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Products = LoadProducts();
            ProductComponents = LoadProductComponents();
            Clients = LoadClients();
            Warehouses = LoadWarehouses();
            WarehouseComponents = LoadWarehouseComponents();

        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveProducts();
            SaveProductComponents();
            SaveWarehouses();
            SaveWarehouseComponents();
            SaveClients();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Product> LoadProducts()
        {
            var list = new List<Product>();
            if (File.Exists(ProductFileName))
            {
                XDocument xDocument = XDocument.Load(ProductFileName);
                var xElements = xDocument.Root.Elements("Product").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Product
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductName = elem.Element("ProductName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();

            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FIO = elem.Element("FIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }

            return list;
        }
        private List<ProductComponent> LoadProductComponents()
        {
            var list = new List<ProductComponent>();
            if (File.Exists(ProductComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ProductComponentFileName);
                var xElements = xDocument.Root.Elements("ProductComponent").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new ProductComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();

            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value
                    });
                }
            }

            return list;
        }

        private List<WarehouseComponent> LoadWarehouseComponents()
        {
            var list = new List<WarehouseComponent>();

            if (File.Exists(WarehouseComponentFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseComponentFileName);
                var xElements = xDocument.Root.Elements("WarehouseComponent").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new WarehouseComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseId = Convert.ToInt32(elem.Element("WarehouseId").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }

            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                       new XElement("ClientId", order.ClientId),
                    new XElement("ProductId", order.ProductId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveProducts()
        {
            if (Products != null)
            {
                var xElement = new XElement("Products");
                foreach (var product in Products)
                {
                    xElement.Add(new XElement("Product",
                    new XAttribute("Id", product.Id),
                    new XElement("ProductName", product.ProductName),
                    new XElement("Price", product.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");

                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("FIO", client.FIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveProductComponents()
        {
            if (ProductComponents != null)
            {
                var xElement = new XElement("ProductComponents");
                foreach (var productComponent in ProductComponents)
                {
                    xElement.Add(new XElement("ProductComponent",
                    new XAttribute("Id", productComponent.Id),
                    new XElement("ProductId", productComponent.ProductId),
                    new XElement("ComponentId", productComponent.ComponentId),
                    new XElement("Count", productComponent.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductComponentFileName);
            }
        }
        private void SaveWarehouses()
        {
            if (ProductComponents != null)
            {
                var xElement = new XElement("Warehouses");

                foreach (var warehouse in Warehouses)
                {
                    xElement.Add(new XElement("Warehouse",
                    new XAttribute("Id", warehouse.Id),
                    new XElement("WarehouseName", warehouse.WarehouseName)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }

        private void SaveWarehouseComponents()
        {
            if (WarehouseComponents != null)
            {
                var xElement = new XElement("WarehouseComponents");

                foreach (var warehouseComponent in WarehouseComponents)
                {
                    xElement.Add(new XElement("WarehouseComponent",
                    new XAttribute("Id", warehouseComponent.Id),
                    new XElement("WarehouseId", warehouseComponent.WarehouseId),
                    new XElement("ComponentId", warehouseComponent.ComponentId),
                    new XElement("Count", warehouseComponent.Count)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseComponentFileName);
            }
        }
    }
}