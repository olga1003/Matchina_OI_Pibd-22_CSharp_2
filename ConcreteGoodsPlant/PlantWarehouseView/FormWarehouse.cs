using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlantWarehouseView
{
    public partial class FormWarehouse : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<WarehouseComponentViewModel> warehouseComponent;
        public FormWarehouse()
        {
            InitializeComponent();
        }    

        private void FormWarehouse_Load(object sender, EventArgs e)
        {           
                 dataGridView.Columns.Add("Id", "Id");
                 dataGridView.Columns.Add("Компонент", "Компонент");
                 dataGridView.Columns.Add("Количество", "Количество");
                 dataGridView.Columns[0].Visible = false;
                 dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                 if (id.HasValue)
                 {
                     try
                     {
                         WarehouseViewModel view = APIWarehouse.GetRequest<WarehouseViewModel>($"api/warehouse/getwarehouse?warehouseId={id.Value}");
                         if (view != null)
                         {
                        warehouseNameTextBox.Text = view.WarehouseName;
                        warehouseComponent = view.WarehouseComponents;
                             LoadData();
                         }
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
                 else
                 {
                     warehouseComponent = new List<WarehouseComponentViewModel>();
                 }
        }
        private void LoadData()
        {
            try
            {
                if (warehouseComponent != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var wc in warehouseComponent)
                    {
                        dataGridView.Rows.Add(new object[] { wc.Id, wc.ComponentName, wc.Count });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(warehouseNameTextBox.Text))
            {
                MessageBox.Show("Заполните поле Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIWarehouse.PostRequest("api/Warehouse/createorupdatewarehouse", new WarehouseBindingModel
                {
                    Id = id,
                    WarehouseName = warehouseNameTextBox.Text
                });
                MessageBox.Show("Успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}