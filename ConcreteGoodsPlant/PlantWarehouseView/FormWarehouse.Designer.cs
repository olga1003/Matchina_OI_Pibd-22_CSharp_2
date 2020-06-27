namespace PlantWarehouseView
{
    partial class FormWarehouse
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
            this.warehouseNameLabel = new System.Windows.Forms.Label();
            this.warehouseNameTextBox = new System.Windows.Forms.TextBox();
            this.detailGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.detailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // warehouseNameLabel
            // 
            this.warehouseNameLabel.AutoSize = true;
            this.warehouseNameLabel.Location = new System.Drawing.Point(24, 19);
            this.warehouseNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warehouseNameLabel.Name = "warehouseNameLabel";
            this.warehouseNameLabel.Size = new System.Drawing.Size(80, 20);
            this.warehouseNameLabel.TabIndex = 0;
            this.warehouseNameLabel.Text = "Название:";
            // 
            // warehouseNameTextBox
            // 
            this.warehouseNameTextBox.Location = new System.Drawing.Point(112, 14);
            this.warehouseNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.warehouseNameTextBox.Name = "warehouseNameTextBox";
            this.warehouseNameTextBox.Size = new System.Drawing.Size(311, 27);
            this.warehouseNameTextBox.TabIndex = 1;
            // 
            // detailGroupBox
            // 
            this.detailGroupBox.Controls.Add(this.dataGridView);
            this.detailGroupBox.Location = new System.Drawing.Point(15, 66);
            this.detailGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.detailGroupBox.Name = "detailGroupBox";
            this.detailGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.detailGroupBox.Size = new System.Drawing.Size(540, 557);
            this.detailGroupBox.TabIndex = 2;
            this.detailGroupBox.TabStop = false;
            this.detailGroupBox.Text = "Компоненты";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 29);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(537, 526);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(347, 632);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 35);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(455, 632);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 35);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 682);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.detailGroupBox);
            this.Controls.Add(this.warehouseNameTextBox);
            this.Controls.Add(this.warehouseNameLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            this.detailGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warehouseNameLabel;
        private System.Windows.Forms.TextBox warehouseNameTextBox;
        private System.Windows.Forms.GroupBox detailGroupBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}