﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlantWarehouseView
{
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPassword.Text))
            {
                if (textBoxPassword.Text == ConfigurationManager.AppSettings["123"])
                {
                    Program.IsLogined = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}