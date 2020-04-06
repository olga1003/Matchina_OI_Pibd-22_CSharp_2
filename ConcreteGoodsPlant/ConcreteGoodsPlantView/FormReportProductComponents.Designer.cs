namespace ConcreteGoodsPlantView
{
    partial class FormReportProductComponents
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
            this.ReportProductComponentViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ButtonSaveToPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductComponentViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportProductComponentViewModelBindingSource
            // 
            this.ReportProductComponentViewModelBindingSource.DataSource = typeof(PlantBusinessLogic.ViewModels.ReportProductComponentViewModel);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportProductComponentViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "ConcreteGoodsPlantView.ReportProductComponent.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(3, 50);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(948, 503);
            this.reportViewer.TabIndex = 1;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load);
            // 
            // ButtonSaveToPDF
            // 
            this.ButtonSaveToPDF.Location = new System.Drawing.Point(12, 12);
            this.ButtonSaveToPDF.Name = "ButtonSaveToPDF";
            this.ButtonSaveToPDF.Size = new System.Drawing.Size(194, 30);
            this.ButtonSaveToPDF.TabIndex = 6;
            this.ButtonSaveToPDF.Text = "Сохранить  в PDF";
            this.ButtonSaveToPDF.UseVisualStyleBackColor = true;
            this.ButtonSaveToPDF.Click += new System.EventHandler(this.ButtonSaveToPDF_Click);
            // 
            // FormReportProductComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 565);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.ButtonSaveToPDF);
            this.Name = "FormReportProductComponents";
            this.Text = "Компоненты и изделия";
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductComponentViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonSaveToPDF;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportProductComponentViewModelBindingSource;
    }
}