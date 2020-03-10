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

        private void FormMenu_Load(object sender, EventArgs e)
        {
            FeltoltIngatlanokListView();
            FeltoltUgynokokListView();

            FeltoltIngatlanAllapotokComboBox(comboBoxIngAllapotok);
            FeltoltIngatlanAllapotokComboBox(comboBoxIngatlanAllapotok);

            FeltoltIngatlanKategoriakComboBox(comboBoxIngatlanKategoriak);
            FeltoltIngatlanKategoriakComboBox(comboBoxIngKategoriak);

            FeltoltTelepulesekComboBox(comboBoxIngatlanTelepulesek);
            FeltoltTelepulesekComboBox(comboBoxIngTelepulesek);
            FeltoltTelepulesekComboBox(comboBoxEladoTelepules);

            FeltoltUgynokJogosultsagokComboBox();

            toolStripStatusLabelSession.Text += $" {Munkamenet.UgynokAzonosito} ({Munkamenet.UgynokNeve})";
        }

        #region ComboBox

        private void comboBoxUgynokJogosultsagok_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelUgynokJogosultsagLeiras.Text = ugynokJogosultsagService.GetUgynokJogosultsag(comboBoxUgynokJogosultsagok.SelectedItem.ToString()).Leiras;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FeltoltUgynokJogosultsagokComboBox()
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

        private void listViewUgynokok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUgynokok.SelectedItems.Count > 0)
            {
                textBoxUgynokAzonosito.ReadOnly = true;
                textBoxUgynokAzonosito.Text = listViewUgynokok.SelectedItems[0].Text;

                Ugynok ugynok = ugynokService.GetUgynok(textBoxUgynokAzonosito.Text);
                textBoxUgynokJelszo.Text = ugynok.Jelszo;

                textBoxUgynokVezeteknev.Text = listViewUgynokok.SelectedItems[0].SubItems[1].Text;
                textBoxUgynokKeresztnev.Text = listViewUgynokok.SelectedItems[0].SubItems[2].Text;
                textBoxUgynokTelefonszam.Text = listViewUgynokok.SelectedItems[0].SubItems[3].Text;

                comboBoxUgynokJogosultsagok.SelectedItem = listViewUgynokok.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                textBoxUgynokAzonosito.ReadOnly = false;
                textBoxUgynokAzonosito.Clear();
                textBoxUgynokJelszo.Clear();
                textBoxUgynokVezeteknev.Clear();
                textBoxUgynokKeresztnev.Clear();
                textBoxUgynokTelefonszam.Clear();
                FeltoltUgynokJogosultsagokComboBox();
                labelUgynokJogosultsagLeiras.Text = "";
            }
        }

        private void FeltoltIngatlanokListView()
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

        private void FeltoltUgynokokListView()
        {
            foreach (Ugynok ugynok in ugynokService.GetUgynokok())
            {
                ListViewItem listViewItemUgynokok = new ListViewItem();

                listViewItemUgynokok.Text = ugynok.Id;
                listViewItemUgynokok.SubItems.Add(ugynok.Vezeteknev);
                listViewItemUgynokok.SubItems.Add(ugynok.Keresztnev);
                listViewItemUgynokok.SubItems.Add(ugynok.Telefonszam);
                listViewItemUgynokok.SubItems.Add(ugynok.Jogosultsag);

                listViewUgynokok.Items.Add(listViewItemUgynokok);
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

        private void buttonHozzaadUgynokot_Click(object sender, EventArgs e)
        {
            try
            {
                Ugynok ugynok = new Ugynok();
                ugynok.Id = textBoxUgynokAzonosito.Text;
                ugynok.Jelszo = textBoxUgynokJelszo.Text;
                ugynok.Vezeteknev = textBoxUgynokVezeteknev.Text;
                ugynok.Keresztnev = textBoxUgynokKeresztnev.Text;
                ugynok.Telefonszam = textBoxUgynokTelefonszam.Text;
                ugynok.Jogosultsag = comboBoxUgynokJogosultsagok.SelectedItem.ToString();

                ugynokService.HozzaadUgynok(ugynok);


                ListViewItem listViewItemUjUgynok = new ListViewItem();

                listViewItemUjUgynok.Text = ugynok.Id;
                listViewItemUjUgynok.SubItems.Add(ugynok.Vezeteknev);
                listViewItemUjUgynok.SubItems.Add(ugynok.Keresztnev);
                listViewItemUjUgynok.SubItems.Add(ugynok.Telefonszam);
                listViewItemUjUgynok.SubItems.Add(ugynok.Jogosultsag);

                listViewUgynokok.Items.Add(listViewItemUjUgynok);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUgynokModositas_Click(object sender, EventArgs e)
        {
            try
            {
                Ugynok ugynok = ugynokService.GetUgynok(textBoxUgynokAzonosito.Text);
                ugynok.Jelszo = textBoxUgynokJelszo.Text;
                ugynok.Vezeteknev = textBoxUgynokVezeteknev.Text;
                ugynok.Keresztnev = textBoxUgynokKeresztnev.Text;
                ugynok.Telefonszam = textBoxUgynokTelefonszam.Text;

                ugynokService.ModositUgynok(ugynok);

                listViewUgynokok.SelectedItems[0].SubItems[1].Text = ugynok.Vezeteknev;
                listViewUgynokok.SelectedItems[0].SubItems[2].Text = ugynok.Keresztnev;
                listViewUgynokok.SelectedItems[0].SubItems[3].Text = ugynok.Telefonszam;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModositUgynokJogosultsag_Click(object sender, EventArgs e)
        {
            Ugynok ugynok = ugynokService.GetUgynok(textBoxUgynokAzonosito.Text);
            ugynok.Jogosultsag = comboBoxUgynokJogosultsagok.SelectedItem.ToString();

            try
            {
                ugynokService.ModositUgynok(ugynok);

                listViewUgynokok.SelectedItems[0].SubItems[4].Text = ugynok.Jogosultsag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
