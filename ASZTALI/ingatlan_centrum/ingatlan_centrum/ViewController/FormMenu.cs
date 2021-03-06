﻿using IngatlanCentrum.Config;
using IngatlanCentrum.Model;
using IngatlanCentrum.Service;
using IngatlanCentrum.Validation;
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

        private void IngatlanEsEladoPanelenVezerlokAlaphelyzetbeAllitasa()
        {
            textBoxHelyrajziSzam.Clear();
            FeltoltTelepulesekComboBox(comboBoxIngatlanTelepulesek);
            textBoxAlapterulet.Clear();
            numericUpDownIngatlanSzobakSzama.Value = 0;
            FeltoltIngatlanKategoriakComboBox(comboBoxIngatlanKategoriak);
            FeltoltIngatlanAllapotokComboBox(comboBoxIngatlanAllapotok);
            textBoxEladoVezeteknev.Clear();
            textBoxEladoKeresztnev.Clear();
            FeltoltTelepulesekComboBox(comboBoxEladoTelepules);
            textBoxEladoLakcim.Clear();
            textBoxEladoAdoszam.Clear();
            textBoxEladoTelefonszam.Clear();
            textBoxEladoEmail.Clear();
            FeltoltMeglevoEladokComboBox();
        }

        private void HirdetesPanelVezerloketAlaphelyzetbeAllit()
        {
            textBoxHirdetesbenSzereploCim.Clear();
            textBoxHirdetesLeiras.Clear();
            textBoxMeghirdetettAr.Clear();
        }

        private void UgynokPanelenVezerlokAlaphelyzetbeAllitasa()
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

        private void FeltoltIngatlanokListView()
        {
            foreach (Ingatlan ingatlan in ingatlanService.GetIngatlanok())
            {
                ListViewItem listViewItemIngatlanok = new ListViewItem();
                listViewItemIngatlanok.Text = ingatlan.HelyrajziSzam;
                listViewItemIngatlanok.SubItems.Add(ingatlan.Telepules);
                listViewItemIngatlanok.SubItems.Add(ingatlan.Alapterulet.ToString());
                listViewItemIngatlanok.SubItems.Add(ingatlan.SzobakSzama.ToString());
                listViewItemIngatlanok.SubItems.Add(ingatlan.Kategoria);
                listViewItemIngatlanok.SubItems.Add(ingatlan.Allapot);
                listViewIngatlanok.Items.Add(listViewItemIngatlanok);
            }
        }

        private void FeltoltHirdetesekListView()
        {
            foreach (Hirdetes hirdetes in hirdetesService.GetHirdetesek())
            {
                ListViewItem listViewItemHirdetesek = new ListViewItem();

                listViewItemHirdetesek.Text = hirdetes.Id.ToString();
                listViewItemHirdetesek.SubItems.Add(hirdetes.Ingatlan.HelyrajziSzam);
                listViewItemHirdetesek.SubItems.Add(hirdetes.Cim);
                listViewItemHirdetesek.SubItems.Add(hirdetes.Leiras);
                listViewItemHirdetesek.SubItems.Add(hirdetes.Ar.ToString("C0"));
                listViewItemHirdetesek.SubItems.Add(Convert.ToDateTime(hirdetes.Datum).ToString("yyyy-MM-dd hh:mm:ss"));

                if (hirdetes.Aktiv)
                {
                    listViewItemHirdetesek.SubItems.Add("Igen");
                }
                else
                {
                    listViewItemHirdetesek.SubItems.Add("Nem");
                }

                listViewHirdetesek.Items.Add(listViewItemHirdetesek);
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

        private void FeltoltMeglevoEladokComboBox()
        {
            comboBoxMeglevoEladok.Items.Clear();

            foreach (Elado elado in eladoService.GetEladok())
            {
                comboBoxMeglevoEladok.Items.Add($"{elado.Vezeteknev} {elado.Keresztnev}");
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

        private void FeltoltHirdetendoIngatlanokComboBox()
        {
            comboBoxHirdetesIngatlanok.Items.Clear();

            foreach (Ingatlan ingatlan in ingatlanService.GetIngatlanok())
            {
                if (!hirdetesService.IngatlanSzerepelEHirdetesben(ingatlan.HelyrajziSzam))
                {
                    comboBoxHirdetesIngatlanok.Items.Add(ingatlan.HelyrajziSzam);
                }
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();

            FeltoltIngatlanokListView();
            FeltoltUgynokokListView();
            FeltoltHirdetesekListView();
            FeltoltIngatlanAllapotokComboBox(comboBoxIngatlanAllapotok);
            FeltoltIngatlanKategoriakComboBox(comboBoxIngatlanKategoriak);
            FeltoltTelepulesekComboBox(comboBoxIngatlanTelepulesek);
            FeltoltTelepulesekComboBox(comboBoxEladoTelepules);
            FeltoltUgynokJogosultsagokComboBox();
            FeltoltHirdetendoIngatlanokComboBox();
            FeltoltMeglevoEladokComboBox();

            buttonIngatlanModositas.Visible = false;
            buttonEladoModositas.Visible = false;

            buttonHirdetesHozzaadas.Visible = false;
            buttonHirdetesModositas.Visible = false;
            buttonHirdetesDeaktivalas.Visible = false;
            buttonHirdetesAktivalas.Visible = false;

            buttonUgynokModositas.Visible = false;
            buttonModositUgynokJogosultsag.Visible = false;

            textBoxHirdetesAzonosito.Text = hirdetesService.GetNextHirdetesId().ToString();
            toolStripStatusLabelSession.Text += $" {Munkamenet.UgynokNeve} ({Munkamenet.UgynokAzonosito}, {Munkamenet.UgynokJogosultsag})";
        }

        #region ComboBox

        private void comboBoxMeglevoEladok_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxEladoAdatai.Visible = false;
        }

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

        private void comboBoxHirdetesIngatlanok_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonHirdetesModositas.Visible = false;
            buttonHirdetesDeaktivalas.Visible = false;
            buttonHirdetesAktivalas.Visible = false;
            buttonHirdetesHozzaadas.Visible = true;

            HirdetesPanelVezerloketAlaphelyzetbeAllit();

            string helyrajziSzam = comboBoxHirdetesIngatlanok.SelectedItem.ToString();
            Ingatlan ingatlan = ingatlanService.GetIngatlan(helyrajziSzam);

            labelHirdetesbenSzereploIngatlanEsEladoAdatok.Text = "";
            labelHirdetesbenSzereploIngatlanEsEladoAdatok.Text +=
                $"Ingatlan adatai\n\nalapterület: {ingatlan.Alapterulet} m2\n" +
                $"szobák száma: {ingatlan.SzobakSzama}\ntelepülés: {ingatlan.Telepules}\n" +
                $"kategória: {ingatlan.Kategoria}\nállapot: {ingatlan.Allapot}\n\n" +
                $"Eladó neve: {ingatlan.Elado.Vezeteknev} {ingatlan.Elado.Keresztnev}\n" +
                $"telefonszám: {ingatlan.Elado.Telefonszam}\ne-mail cím: {ingatlan.Elado.Email}";

            textBoxHirdetesAzonosito.Text = hirdetesService.GetNextHirdetesId().ToString();
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
            if (Munkamenet.UgynokJogosultsag == "default")
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
                labelMeglevoEladok.Visible = false;
                comboBoxMeglevoEladok.Visible = false;
                buttonUjIngatlan.Visible = false;
                buttonIngatlanModositas.Visible = true;
                buttonEladoModositas.Visible = true;
                textBoxEladoAdoszam.ReadOnly = true;
                textBoxHelyrajziSzam.ReadOnly = true;
                groupBoxEladoAdatai.Visible = true;

                textBoxHelyrajziSzam.Text = listViewIngatlanok.SelectedItems[0].Text;
                comboBoxIngatlanTelepulesek.SelectedItem = listViewIngatlanok.SelectedItems[0].SubItems[1].Text;
                textBoxAlapterulet.Text = listViewIngatlanok.SelectedItems[0].SubItems[2].Text;
                numericUpDownIngatlanSzobakSzama.Value = Convert.ToDecimal(listViewIngatlanok.SelectedItems[0].SubItems[3].Text);
                comboBoxIngatlanKategoriak.SelectedItem = listViewIngatlanok.SelectedItems[0].SubItems[4].Text;
                comboBoxIngatlanAllapotok.SelectedItem = listViewIngatlanok.SelectedItems[0].SubItems[5].Text;

                Elado elado = ingatlanService.GetIngatlan(textBoxHelyrajziSzam.Text).Elado;
                textBoxEladoVezeteknev.Text = elado.Vezeteknev;
                textBoxEladoKeresztnev.Text = elado.Keresztnev;
                textBoxEladoAdoszam.Text = elado.Adoazonosito.ToString();
                comboBoxEladoTelepules.SelectedItem = elado.Telepules;
                textBoxEladoLakcim.Text = elado.Lakcim;
                textBoxEladoTelefonszam.Text = elado.Telefonszam.ToString();
                textBoxEladoEmail.Text = elado.Email;
            }
            else
            {
                buttonUjIngatlan.Visible = true;
                labelMeglevoEladok.Visible = true;
                comboBoxMeglevoEladok.Visible = true;
                buttonIngatlanModositas.Visible = false;
                buttonEladoModositas.Visible = false;
                textBoxEladoAdoszam.ReadOnly = false;
                textBoxHelyrajziSzam.ReadOnly = false;
                groupBoxEladoAdatai.Visible = true;

                IngatlanEsEladoPanelenVezerlokAlaphelyzetbeAllitasa();
            }
        }

        private void listViewHirdetesek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewHirdetesek.SelectedItems.Count > 0)
            {
                buttonHirdetesHozzaadas.Visible = false;
                buttonHirdetesModositas.Visible = true;
                buttonHirdetesAktivalas.Visible = true;
                buttonHirdetesDeaktivalas.Visible = true;

                labelHirdetesbenSzereploIngatlanEsEladoAdatok.Text = "";
                FeltoltHirdetendoIngatlanokComboBox();

                int hirdetesAzonosito = Convert.ToInt32(listViewHirdetesek.SelectedItems[0].Text);
                textBoxHirdetesAzonosito.Text = hirdetesAzonosito.ToString();
                textBoxHirdetesbenSzereploCim.Text = listViewHirdetesek.SelectedItems[0].SubItems[2].Text;
                textBoxHirdetesLeiras.Text = listViewHirdetesek.SelectedItems[0].SubItems[3].Text;

                Hirdetes hirdetes = hirdetesService.GetHirdetes(hirdetesAzonosito);
                textBoxMeghirdetettAr.Text = hirdetes.Ar.ToString();
            }
            else
            {
                textBoxHirdetesAzonosito.Text = hirdetesService.GetNextHirdetesId().ToString();
                buttonHirdetesHozzaadas.Visible = true;
                buttonHirdetesModositas.Visible = false;
                buttonHirdetesDeaktivalas.Visible = false;
                buttonHirdetesAktivalas.Visible = false;
                HirdetesPanelVezerloketAlaphelyzetbeAllit();
            }
        }

        private void listViewUgynokok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUgynokok.SelectedItems.Count > 0)
            {
                buttonUgynokModositas.Visible = true;
                buttonModositUgynokJogosultsag.Visible = true;
                buttonHozzaadUgynokot.Visible = false;

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
                buttonHozzaadUgynokot.Visible = true;
                buttonModositUgynokJogosultsag.Visible = false;
                buttonUgynokModositas.Visible = false;

                UgynokPanelenVezerlokAlaphelyzetbeAllitasa();
            }
        }

        #endregion

        #region Gombok

        private void buttonUjIngatlan_Click(object sender, EventArgs e)
        {
            try
            {
                Elado elado = new Elado();

                elado.Vezeteknev = textBoxEladoVezeteknev.Text;
                elado.Keresztnev = textBoxEladoKeresztnev.Text;
                elado.Adoazonosito = textBoxEladoAdoszam.Text;

                if (comboBoxEladoTelepules.SelectedIndex >= 0)
                {
                    elado.Telepules = comboBoxEladoTelepules.SelectedItem.ToString();
                }

                elado.Lakcim = textBoxEladoLakcim.Text;
                elado.Telefonszam = textBoxEladoTelefonszam.Text;
                elado.Email = textBoxEladoEmail.Text;

                if (comboBoxMeglevoEladok.SelectedIndex >= 0)
                {
                    elado = eladoService.GetElado(comboBoxMeglevoEladok.SelectedItem.ToString());
                }

                Ingatlan ingatlan = new Ingatlan();
                ingatlan.HelyrajziSzam = textBoxHelyrajziSzam.Text;

                if (comboBoxIngatlanTelepulesek.SelectedIndex >= 0)
                {
                    ingatlan.Telepules = comboBoxIngatlanTelepulesek.SelectedItem.ToString();
                }

                if (!string.IsNullOrEmpty(textBoxAlapterulet.Text))
                {
                    ingatlan.Alapterulet = Convert.ToInt32(textBoxAlapterulet.Text);
                }

                ingatlan.SzobakSzama = Convert.ToInt32(numericUpDownIngatlanSzobakSzama.Value);
                 
                if (comboBoxIngatlanKategoriak.SelectedIndex >= 0)
                {
                    ingatlan.Kategoria = comboBoxIngatlanKategoriak.SelectedItem.ToString();
                }

                if (comboBoxIngatlanAllapotok.SelectedIndex >= 0)
                {
                    ingatlan.Allapot = comboBoxIngatlanAllapotok.SelectedItem.ToString();
                }

                ingatlan.Elado = elado;

                EladoValidator.Validate(elado);
                IngatlanValidator.Validate(ingatlan);

                if (comboBoxMeglevoEladok.SelectedIndex < 0)
                {
                    eladoService.HozzaadElado(elado);
                }

                ingatlanService.HozzaadIngatlan(ingatlan);

                ListViewItem listViewItemUjIngatlan = new ListViewItem();
                listViewItemUjIngatlan.Text = ingatlan.HelyrajziSzam;
                listViewItemUjIngatlan.SubItems.Add(ingatlan.Telepules);
                listViewItemUjIngatlan.SubItems.Add(ingatlan.Alapterulet.ToString());
                listViewItemUjIngatlan.SubItems.Add(ingatlan.SzobakSzama.ToString());
                listViewItemUjIngatlan.SubItems.Add(ingatlan.Kategoria);
                listViewItemUjIngatlan.SubItems.Add(ingatlan.Allapot);
                listViewIngatlanok.Items.Add(listViewItemUjIngatlan);

                IngatlanEsEladoPanelenVezerlokAlaphelyzetbeAllitasa();
                FeltoltHirdetendoIngatlanokComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonIngatlanModositas_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewIngatlanok.SelectedItems.Count > 0)
                {
                    int index = listViewIngatlanok.FocusedItem.Index;

                    Ingatlan ingatlan = new Ingatlan();
                    ingatlan.HelyrajziSzam = textBoxHelyrajziSzam.Text;
                    ingatlan.Telepules = comboBoxIngatlanTelepulesek.SelectedItem.ToString();
                    ingatlan.Alapterulet = Convert.ToInt32(textBoxAlapterulet.Text);
                    ingatlan.SzobakSzama = Convert.ToInt32(numericUpDownIngatlanSzobakSzama.Value);
                    ingatlan.Kategoria = comboBoxIngatlanKategoriak.SelectedItem.ToString();
                    ingatlan.Allapot = comboBoxIngatlanAllapotok.SelectedItem.ToString();
                    ingatlan.Elado = eladoService.GetEladoAdoazonositoAlapjan(textBoxEladoAdoszam.Text);

                    IngatlanValidator.Validate(ingatlan);

                    ingatlanService.ModositIngatlan(ingatlan);

                    ListViewItem listViewItemModositottIngatlan = new ListViewItem();
                    listViewItemModositottIngatlan.Text = ingatlan.HelyrajziSzam;
                    listViewItemModositottIngatlan.SubItems.Add(ingatlan.Telepules);
                    listViewItemModositottIngatlan.SubItems.Add(ingatlan.Alapterulet.ToString());
                    listViewItemModositottIngatlan.SubItems.Add(ingatlan.SzobakSzama.ToString());
                    listViewItemModositottIngatlan.SubItems.Add(ingatlan.Kategoria);
                    listViewItemModositottIngatlan.SubItems.Add(ingatlan.Allapot);

                    listViewIngatlanok.Items.RemoveAt(index);
                    listViewIngatlanok.Items.Insert(index, listViewItemModositottIngatlan);

                    IngatlanEsEladoPanelenVezerlokAlaphelyzetbeAllitasa();
                }
                else
                {
                    MessageBox.Show("Nincs kijelölt ingatlan módosításhoz!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEladoModositas_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewIngatlanok.SelectedItems.Count > 0)
                {
                    Elado elado = new Elado();
                    elado.Vezeteknev = textBoxEladoVezeteknev.Text;
                    elado.Keresztnev = textBoxEladoKeresztnev.Text;
                    elado.Adoazonosito = textBoxEladoAdoszam.Text;
                    elado.Telepules = comboBoxEladoTelepules.SelectedItem.ToString();
                    elado.Lakcim = textBoxEladoLakcim.Text;
                    elado.Telefonszam = textBoxEladoTelefonszam.Text;
                    elado.Email = textBoxEladoEmail.Text;

                    EladoValidator.Validate(elado);

                    string helyrajziSzam = textBoxHelyrajziSzam.Text;

                    Ingatlan ingatlan = ingatlanService.GetIngatlan(helyrajziSzam);
                    ingatlan.Elado = elado;
                    ingatlanService.ModositIngatlan(ingatlan);

                    eladoService.ModositElado(elado);
                    ingatlanService.ModositEladotIngatlanban(elado.Adoazonosito, elado);
                }
                else
                {
                    MessageBox.Show("Nincs kijelölt eladó módosításhoz!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHirdetesHozzaadas_Click(object sender, EventArgs e)
        {
            try
            {
                string helyrajziSzam = "";

                if (comboBoxHirdetesIngatlanok.SelectedIndex >= 0)
                {
                    helyrajziSzam = comboBoxHirdetesIngatlanok.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Nincs kijelölt ingatlan meghirdetéshez!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Hirdetes hirdetes = new Hirdetes();
                hirdetes.Id = Convert.ToInt32(textBoxHirdetesAzonosito.Text);
                hirdetes.Cim = textBoxHirdetesbenSzereploCim.Text;
                hirdetes.Leiras = textBoxHirdetesLeiras.Text;

                if (!string.IsNullOrEmpty(textBoxMeghirdetettAr.Text))
                {
                    hirdetes.Ar = Convert.ToInt32(textBoxMeghirdetettAr.Text);
                }

                hirdetes.Ingatlan = ingatlanService.GetIngatlan(helyrajziSzam);
                hirdetes.Ugynok = ugynokService.GetUgynok(Munkamenet.UgynokAzonosito);
                hirdetes.Datum = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                hirdetes.Aktiv = true;

                HirdetesValidator.Validate(hirdetes);

                hirdetesService.HozzaadHirdetes(hirdetes);
                FeltoltHirdetendoIngatlanokComboBox();

                ListViewItem listViewItemUjHirdetes = new ListViewItem();
                listViewItemUjHirdetes.Text = hirdetes.Id.ToString();
                listViewItemUjHirdetes.SubItems.Add(hirdetes.Ingatlan.HelyrajziSzam);
                listViewItemUjHirdetes.SubItems.Add(hirdetes.Cim);
                listViewItemUjHirdetes.SubItems.Add(hirdetes.Leiras);
                listViewItemUjHirdetes.SubItems.Add(hirdetes.Ar.ToString("C0"));
                listViewItemUjHirdetes.SubItems.Add(hirdetes.Datum);

                if (hirdetes.Aktiv)
                {
                    listViewItemUjHirdetes.SubItems.Add("Igen");
                }
                else
                {
                    listViewItemUjHirdetes.SubItems.Add("Nem");
                }

                listViewHirdetesek.Items.Add(listViewItemUjHirdetes);

                HirdetesPanelVezerloketAlaphelyzetbeAllit();

                textBoxHirdetesAzonosito.Text = hirdetesService.GetNextHirdetesId().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHirdetesModositas_Click(object sender, EventArgs e)
        {
            try
            {
                Hirdetes hirdetes = hirdetesService.GetHirdetes(Convert.ToInt32(textBoxHirdetesAzonosito.Text));
                hirdetes.Cim = textBoxHirdetesbenSzereploCim.Text;
                hirdetes.Leiras = textBoxHirdetesLeiras.Text;

                if (!string.IsNullOrEmpty(textBoxMeghirdetettAr.Text))
                {
                    hirdetes.Ar = Convert.ToInt32(textBoxMeghirdetettAr.Text);
                }

                HirdetesValidator.Validate(hirdetes);

                hirdetesService.ModositHirdetes(hirdetes);

                ListViewItem modositottHirdetesAdatok = new ListViewItem();
                modositottHirdetesAdatok.Text = hirdetes.Id.ToString();
                modositottHirdetesAdatok.SubItems.Add(hirdetes.Ingatlan.HelyrajziSzam);
                modositottHirdetesAdatok.SubItems.Add(hirdetes.Cim);
                modositottHirdetesAdatok.SubItems.Add(hirdetes.Leiras);
                modositottHirdetesAdatok.SubItems.Add(hirdetes.Ar.ToString("C0"));
                modositottHirdetesAdatok.SubItems.Add(hirdetes.Datum);

                if (hirdetes.Aktiv)
                {
                    modositottHirdetesAdatok.SubItems.Add("Igen");
                }
                else
                {
                    modositottHirdetesAdatok.SubItems.Add("Nem");
                }

                int index = listViewHirdetesek.FocusedItem.Index;
                listViewHirdetesek.Items.RemoveAt(index);
                listViewHirdetesek.Items.Insert(index, modositottHirdetesAdatok);

                HirdetesPanelVezerloketAlaphelyzetbeAllit();

                textBoxHirdetesAzonosito.Text = hirdetesService.GetNextHirdetesId().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (comboBoxUgynokJogosultsagok.SelectedIndex >= 0)
                {
                    ugynok.Jogosultsag = comboBoxUgynokJogosultsagok.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Nincs kijelölt ügynök jogosultság!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UgynokValidator.Validate(ugynok);

                ugynokService.HozzaadUgynok(ugynok);

                ListViewItem listViewItemUjUgynok = new ListViewItem();

                listViewItemUjUgynok.Text = ugynok.Id;
                listViewItemUjUgynok.SubItems.Add(ugynok.Vezeteknev);
                listViewItemUjUgynok.SubItems.Add(ugynok.Keresztnev);
                listViewItemUjUgynok.SubItems.Add(ugynok.Telefonszam);
                listViewItemUjUgynok.SubItems.Add(ugynok.Jogosultsag);

                listViewUgynokok.Items.Add(listViewItemUjUgynok);

                UgynokPanelenVezerlokAlaphelyzetbeAllitasa();
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

                UgynokValidator.Validate(ugynok);

                ugynokService.ModositUgynok(ugynok);

                listViewUgynokok.SelectedItems[0].SubItems[1].Text = ugynok.Vezeteknev;
                listViewUgynokok.SelectedItems[0].SubItems[2].Text = ugynok.Keresztnev;
                listViewUgynokok.SelectedItems[0].SubItems[3].Text = ugynok.Telefonszam;

                UgynokPanelenVezerlokAlaphelyzetbeAllitasa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModositUgynokJogosultsag_Click(object sender, EventArgs e)
        {
            try
            {
                Ugynok ugynok = ugynokService.GetUgynok(textBoxUgynokAzonosito.Text);
                ugynok.Jogosultsag = comboBoxUgynokJogosultsagok.SelectedItem.ToString();
                ugynokService.ModositUgynok(ugynok);

                listViewUgynokok.SelectedItems[0].SubItems[4].Text = ugynok.Jogosultsag;

                UgynokPanelenVezerlokAlaphelyzetbeAllitasa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHirdetesDekativalas_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewHirdetesek.SelectedItems.Count > 0)
                {
                    int hirdetesAzonosito = Convert.ToInt32(listViewHirdetesek.SelectedItems[0].Text);
                    Hirdetes hirdetes = hirdetesService.GetHirdetes(hirdetesAzonosito);
                    hirdetesService.HirdetesDeaktivalas(hirdetes);
                    listViewHirdetesek.SelectedItems[0].SubItems[6].Text = "Nem";
                }
                else
                {
                    MessageBox.Show("Nincs kijelölt hirdetés deaktiváláshoz!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHirdetesAktivalas_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewHirdetesek.SelectedItems.Count > 0)
                {
                    int hirdetesAzonosito = Convert.ToInt32(listViewHirdetesek.SelectedItems[0].Text);
                    Hirdetes hirdetes = hirdetesService.GetHirdetes(hirdetesAzonosito);
                    hirdetesService.HirdetesAktivalas(hirdetes);
                    listViewHirdetesek.SelectedItems[0].SubItems[6].Text = "Igen";
                }
                else
                {
                    MessageBox.Show("Nincs kijelölt hirdetés aktiváláshoz!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if (tabControl.SelectedTab == tabControl.TabPages[2] && Munkamenet.UgynokJogosultsag == "default")
            {
                MessageBox.Show("Default jogosultsággal a felhasználó kezelés nem elérhető!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedTab = tabControl.TabPages[0];
            }
        }

        #endregion
    }
}
