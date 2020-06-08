using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.BusinessLogics;
using PlantBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ConcreteGoodsPlantView
{
    public partial class FormReportWarehouseComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        private readonly IWarehouseLogic warehouseLogic;
        public FormReportWarehouseComponents(ReportLogic logic, IWarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.warehouseLogic = warehouseLogic;
        }
        private void FormReportWarehouseComponents_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = warehouseLogic.GetList();

                if (list != null)
                {
                    dataGridView.Rows.Clear();

                    foreach (var warehouse in list)
                    {
                        int componentsSum = 0;

                        dataGridView.Rows.Add(new object[] { warehouse.WarehouseName, "", "" });

                        foreach (var component in warehouse.WarehouseComponents)
                        {
                            dataGridView.Rows.Add(new object[] { "", component.ComponentName, component.Count });
                            componentsSum += component.Count;
                        }

                        dataGridView.Rows.Add(new object[] { "Итого", "", componentsSum });
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveWarehouseComponentsToExcelFile(new ReportBindingModel { FileName = dialog.FileName });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
