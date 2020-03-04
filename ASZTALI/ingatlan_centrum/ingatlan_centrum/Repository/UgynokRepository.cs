using IngatlanCentrum.Model;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;

namespace IngatlanCentrum.Repository
{
    public partial class Repository
    {
        /// <summary>
        /// Ügynököket tartalmazó lista
        /// </summary>
        private List<Ugynok> ugynokok;

        /// <summary>
        /// Metódus, amely letölti az ügynökök adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az ügynököket tartalmazó listába.
        /// </summary>
        private void LetoltUgynokoketAdatbazisbol()
        {
            try
            {
                DataTable ugynokTabla = adatbazis.DQL("SELECT * FROM ugynokok;");

                foreach (DataRow row in ugynokTabla.Rows)
                {
                    ugynokok.Add(new Ugynok
                    {
                        Id = row[0].ToString(),
                        Jelszo = row[1].ToString(),
                        Vezeteknev = row[2].ToString(),
                        Keresztnev = row[3].ToString(),
                        Telefonszam = row[4].ToString(),
                        Jogosultsag = row[5].ToString(),
                        Aktiv = Convert.ToBoolean(row[6])
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                throw new Exception("Nem sikerült az ügynök adatok letöltése adatbázisból!");
            }
        }

        public List<Ugynok> GetUgynokok()
        {
            if (ugynokok == null)
            {
                ugynokok = new List<Ugynok>();
                LetoltUgynokoketAdatbazisbol();
                return ugynokok;
            }

            return ugynokok;
        }

        public void HozzaadUgynok(Ugynok ugynok)
        {
            ugynokok.Add(ugynok);
        }

        public void ModositUgynok(Ugynok ugynok)
        {
            foreach (Ugynok u in ugynokok)
            {
                if (u.Id == ugynok.Id)
                {
                    u.Jelszo = ugynok.Jelszo;
                    u.Vezeteknev = ugynok.Vezeteknev;
                    u.Keresztnev = ugynok.Keresztnev;
                    u.Telefonszam = ugynok.Telefonszam;
                    u.Jogosultsag = ugynok.Jogosultsag;
                    return;
                }
            }

            throw new Exception("Nincs meg a keresett ügynök!\nNem lehet módosítani!");
        }
    }
}
