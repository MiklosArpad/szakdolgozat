using IngatlanCentrum.Config;
using System;
using System.Windows.Forms;

namespace IngatlanCentrum.ViewController
{
    public partial class FormConnection : Form
    {
        public FormConnection()
        {
            InitializeComponent();
        }

        private void comboBoxSzerverTipus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Munkamenet.SzerverTipus = comboBoxSzerverTipus.SelectedItem.ToString();

            FormMenu formMenu = new FormMenu();
            formMenu.Show();
            Hide();
        }
    }
}
