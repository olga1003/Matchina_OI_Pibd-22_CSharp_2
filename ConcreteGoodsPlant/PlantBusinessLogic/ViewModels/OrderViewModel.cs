using PlantBusinessLogic.Attributes;
using PlantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace PlantBusinessLogic.ViewModels
{
    /// Заказ 
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Изделие", width: 100)]
        public string ProductName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
        public override List<string> Properties() => new List<string> 
        { 
            "Id",
            "ClientFIO", 
            "ProductName", 
            "ImplementerFIO", 
            "Count", 
            "Sum", 
            "Status", 
            "DateCreate",
            "DateImplement" };
    }
}
