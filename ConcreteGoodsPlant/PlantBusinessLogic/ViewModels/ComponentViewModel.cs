using System;
using System.Collections.Generic;
using PlantBusinessLogic.Attributes;
using PlantBusinessLogic.Enums;

namespace PlantBusinessLogic.ViewModels
{
    /// Компонент, требуемый для изготовления изделия 
    public class ComponentViewModel : BaseViewModel
    {
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ComponentName"
        };
    }
}
