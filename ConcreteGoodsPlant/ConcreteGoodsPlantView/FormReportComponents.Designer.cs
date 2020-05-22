namespace ConcreteGoodsPlantView
{
    partial class FormReportComponents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportWarehouseComponentViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportWarehouseComponentViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(13, 13);
            this.ButtonToPdf.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(150, 30);
            this.ButtonToPdf.TabIndex = 10;
            this.ButtonToPdf.Text = "В PDF";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetWarehouseComponents";
            reportDataSource1.Value = this.ReportWarehouseComponentViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "ConcreteGoodsPlantView.ReportComponents.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(13, 60);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(774, 377);
            this.reportViewer.TabIndex = 9;
            // 
            // ReportWarehouseComponentViewModelBindingSource
            // 
            this.ReportWarehouseComponentViewModelBindingSource.DataSource = typeof(PlantBusinessLogic.ViewModels.ReportWarehouseComponentViewModel);
            // 
            // FormReportComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonToPdf);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportComponents";
            this.Text = "Список компонентов ";
            this.Load += new System.EventHandler(this.reportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportWarehouseComponentViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportWarehouseComponentViewModelBindingSource;
    }
}