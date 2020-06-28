using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PlantBusinessLogic.Attributes;
using PlantBusinessLogic.Enums;

namespace PlantBusinessLogic.ViewModels
{
/// Исполнитель, выполняющий заказы
 /// </summary>
     public class ImplementerViewModel : BaseViewModel
    {
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }
        [Column(title: "Время на заказ", width: 100)]
        public int WorkingTime { get; set; }
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ImplementerFIO",
            "WorkingTime",
            "PauseTime"
        };
    }
}
