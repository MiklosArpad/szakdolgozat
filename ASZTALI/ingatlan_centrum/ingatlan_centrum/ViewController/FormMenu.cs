using IngatlanCentrum.Config;
using IngatlanCentrum.Model;
using IngatlanCentrum.Service;
using System;
using System.Windows.Forms;

namespace IngatlanCentrum.ViewController
{
    public partial class FormMenu : Form
    {
        private EladoService eladoService;
        private HirdetesService hirdetesService;
        private IngatlanAllapotService ingatlanAllapotService;
        private IngatlanKategoriaService ingatlanKategoriaService;
        private IngatlanService ingatlanService;
        private TelepulesService telepulesService;
        private UgynokJogosultsagService ugynokJogosultsagService;
        private UgynokService ugynokService;

        public FormMenu()
        {
            InitializeComponent();

            eladoService = new EladoService();
            hirdetesService = new HirdetesService();
            ingatlanAllapotService = new IngatlanAllapotService();
            ingatlanKategoriaService = new IngatlanKategoriaService();
            ingatlanService = new IngatlanService();
            telepulesService = new TelepulesService();
            ugynokJogosultsagService = new UgynokJogosultsagService();
            ugynokService = new UgynokService();
        }

        private void FormMenu_Load(object sender, System.EventArgs e)
        {
            FeltoltIngatlanokListView(listViewIngatlanok);
            FeltoltUgynokokDataGridView();

            FeltoltIngatlanAllapotokComboBox(comboBoxIngAllapotok);
            FeltoltIngatlanAllapotokComboBox(comboBoxIngatlanAllapotok);

            FeltoltIngatlanKategoriakComboBox(comboBoxIngatlanKategoriak);
            FeltoltIngatlanKategoriakComboBox(comboBoxIngKategoriak);

            FeltoltTelepulesekComboBox(comboBoxIngatlanTelepulesek);
            FeltoltTelepulesekComboBox(comboBoxIngTelepulesek);
            FeltoltTelepulesekComboBox(comboBoxEladoTelepules);

            FeltoltUgynokKategoriakComboBox();

            toolStripStatusLabelSession.Text += $" {Munkamenet.UgynokAzonosito} ({Munkamenet.UgynokNeve})";
        }

        #region ComboBox

        private void FeltoltUgynokKategoriakComboBox()
        {
            comboBoxUgynokJogosultsagok.Items.Clear();

            foreach (UgynokJogosultsag ugynokKategoria in ugynokJogosultsagService.GetUgynokJogosultsagok())
            {
                comboBoxUgynokJogosultsagok.Items.Add(ugynokKategoria.Elnevezes);
            }
        }

        private void FeltoltTelepulesekComboBox(ComboBox comboBoxTelepulesek)
        {
            comboBoxTelepulesek.Items.Clear();

            foreach (Telepules telepules in telepulesService.GetTelepulesek())
            {
                comboBoxTelepulesek.Items.Add(telepules.Nev);
            }
        }

        private void FeltoltIngatlanAllapotokComboBox(ComboBox comboBoxIngatlanAllapotok)
        {
            comboBoxIngatlanAllapotok.Items.Clear();

            foreach (IngatlanAllapot ingatlanAllapot in ingatlanAllapotService.GetIngatlanAllapotok())
            {
                comboBoxIngatlanAllapotok.Items.Add(ingatlanAllapot.Elnevezes);
            }
        }

        private void FeltoltIngatlanKategoriakComboBox(ComboBox comboBoxIngatlanKategoriak)
        {
            comboBoxIngatlanKategoriak.Items.Clear();

            foreach (IngatlanKategoria ingatlanKategoria in ingatlanKategoriaService.GetIngatlanKategoriak())
            {
                comboBoxIngatlanKategoriak.Items.Add(ingatlanKategoria.Elnevezes);
            }
        }

        #endregion

        #region Menüsáv

        private void toolStripMenuItemIngatlanNyilvantartas_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[0];
        }

        private void toolStripMenuItemHirdetesekKezelese_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[1];
        }

        private void toolStripMenuItemFelhasznaloKezeles_Click(object sender, EventArgs e)
        {
            if (Munkamenet.UgynokKategoria == "default")
            {
                MessageBox.Show("Default jogosultsággal a felhasználó kezelés nem elérhető!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tabControl.SelectedTab = tabControl.TabPages[2];
        }

        private void toolStripMenuItemNevjegy_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void toolStripMenuItemKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region ListView

        private void listViewIngatlanok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewIngatlanok.SelectedItems.Count > 0)
            {
                textBoxHelyrajziSzam.Text = listViewIngatlanok.SelectedItems[0].Text;
                comboBoxIngatlanTelepulesek.SelectedItem = listViewIngatlanok.SelectedItems[0].SubItems[1].Text;
                textBoxAlapterulet.Text = listViewIngatlanok.SelectedItems[0].SubItems[2].Text;
                comboBoxIngatlanKategoriak.SelectedItem = listViewIngatlanok.SelectedItems[0].SubItems[3].Text;
                comboBoxIngatlanAllapotok.SelectedItem = listViewIngatlanok.SelectedItems[0].SubItems[4].Text;
                textBoxEladoNev.Text = listViewIngatlanok.SelectedItems[0].SubItems[5].Text;

                Elado elado = ingatlanService.GetIngatlan(textBoxHelyrajziSzam.Text).Tulajdonos;

                textBoxEladoAdoszam.Text = elado.Adoszam.ToString();
                comboBoxEladoTelepules.SelectedItem = elado.Telepules;
                textBoxEladoLakcim.Text = elado.Lakcim;
                textBoxEladoTelefonszam.Text = elado.Telefonszam.ToString();
                textBoxEladoEmail.Text = elado.Email;
            }
        }

        private void FeltoltIngatlanokListView(ListView listViewIngatlanok)
        {
            foreach (Ingatlan ingatlan in ingatlanService.GetIngatlanok())
            {
                ListViewItem listViewItemIngatlanok = new ListViewItem();

                listViewItemIngatlanok.Text = ingatlan.HelyrajziSzam;
                listViewItemIngatlanok.SubItems.Add(ingatlan.Telepules);
                listViewItemIngatlanok.SubItems.Add(ingatlan.Alapterulet.ToString());
                listViewItemIngatlanok.SubItems.Add(ingatlan.Kategoria);
                listViewItemIngatlanok.SubItems.Add(ingatlan.Allapot);
                listViewItemIngatlanok.SubItems.Add(ingatlan.Tulajdonos.Vezeteknev + " " + ingatlan.Tulajdonos.Keresztnev);

                listViewIngatlanok.Items.Add(listViewItemIngatlanok);
            }
        }

        #endregion

        #region DataGridView

        private void dataGridViewUgynokok_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUgynokok.SelectedRows.Count > 0)
            {
                textBoxUgynokAzonosito.Text = dataGridViewUgynokok.SelectedRows[0].Cells[0].Value.ToString();

                Ugynok ugynok = ugynokService.GetUgynok(textBoxUgynokAzonosito.Text);

                textBoxUgynokJelszo.Text = ugynok.Jelszo;
                textBoxUgynokVezeteknev.Text = dataGridViewUgynokok.SelectedRows[0].Cells[1].Value.ToString();
                textBoxUgynokKeresztnev.Text = dataGridViewUgynokok.SelectedRows[0].Cells[2].Value.ToString();
                textBoxUgynokTelefonszam.Text = dataGridViewUgynokok.SelectedRows[0].Cells[3].Value.ToString();

                if (Convert.ToBoolean(dataGridViewUgynokok.SelectedRows[0].Cells[4].Value) == true)
                {
                    checkBoxUgynokAktiv.Checked = true;
                }
                else
                {
                    checkBoxUgynokAktiv.Checked = false;
                }

                comboBoxUgynokJogosultsagok.SelectedItem = dataGridViewUgynokok.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void FeltoltUgynokokDataGridView()
        {
            foreach (Ugynok ugynok in ugynokService.GetUgynokok())
            {
                dataGridViewUgynokok.Rows.Add
                    (ugynok.Id, ugynok.Vezeteknev, ugynok.Keresztnev,
                    ugynok.Telefonszam, ugynok.Aktiv, ugynok.Jogosultsag);
            }
        }

        #endregion

        #region Gombok

        private void buttonUjIngatlan_Click(object sender, EventArgs e)
        {

        }

        private void buttonIngatlanModositas_Click(object sender, EventArgs e)
        {

        }

        private void buttonSzures_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region TabControl

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabControl.TabPages[1] && Munkamenet.UgynokKategoria == "default")
            {
                MessageBox.Show("Default jogosultsággal a felhasználó kezelés nem elérhető!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedTab = tabControl.TabPages[0];
            }
        }

        #endregion
    }
}
