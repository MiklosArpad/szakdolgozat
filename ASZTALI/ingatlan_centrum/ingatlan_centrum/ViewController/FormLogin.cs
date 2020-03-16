﻿using IngatlanCentrum.Service;
using System;
using System.Windows.Forms;

namespace IngatlanCentrum.ViewController
{
    public partial class FormLogin : Form
    {
        private UgynokService ugynokService;

        public FormLogin()
        {
            InitializeComponent();
            ugynokService = new UgynokService();
        }

        private void buttonKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonBelepes_Click(object sender, EventArgs e)
        {
            try
            {
                ugynokService.AzonositUgynok(textBoxUgynokAzonosito.Text, textBoxUgynokJelszo.Text);
                Close();
            }
            catch (Exception ex)
            {
                textBoxUgynokAzonosito.Clear();
                textBoxUgynokJelszo.Clear();
                textBoxUgynokAzonosito.Select();

                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}