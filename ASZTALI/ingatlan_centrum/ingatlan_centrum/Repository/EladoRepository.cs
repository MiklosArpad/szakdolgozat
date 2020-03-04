using IngatlanCentrum.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Data;

namespace IngatlanCentrum.Repository
{
    /// <summary>
    /// Eladó adattár
    /// </summary>
    public partial class Repository
    {
        /// <summary>
        /// Eladókat tartalmazó lista
        /// </summary>
        private List<Elado> eladok;

        /// <summary>
        /// Metódus, amely letölti az eladók adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az eladókat tartalmazó listába.
        /// </summary>
        private void LetoltEladokatAdatbazisbol()
        {
            try
            {
                DataTable eladoTabla = adatbazis.DQL("SELECT * FROM eladok;");

                foreach (DataRow row in eladoTabla.Rows)
                {
                    eladok.Add(new Elado
                    {
                        Id = Convert.ToInt32(row[0]),
                        Vezeteknev = row[1].ToString(),
                        Keresztnev = row[2].ToString(),
                        Adoszam = Convert.ToInt32(row[3]),
                        Telepules = row[4].ToString(),
                        Lakcim = row[5].ToString(),
                        Telefonszam = row[6].ToString(),
                        Email = row[7].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                throw new Exception("Nem sikerült az eladó adatok letöltése adatbázisból!");
            }
        }

        public List<Elado> GetEladok()
        {
            if (eladok == null)
            {
                eladok = new List<Elado>();
                LetoltEladokatAdatbazisbol();
                return eladok;
            }

            return eladok;
        }

        public void HozzaadElado(Elado elado)
        {
            eladok.Add(elado);
        }

        public void ModositElado(Elado elado)
        {
            foreach (Elado e in eladok)
            {
                if (e.Id == elado.Id)
                {
                    e.Vezeteknev = elado.Vezeteknev;
                    e.Keresztnev = elado.Keresztnev;
                    e.Adoszam = elado.Adoszam;
                    e.Telepules = elado.Telepules;
                    e.Lakcim = elado.Lakcim;
                    e.Telefonszam = elado.Telefonszam;
                    e.Email = elado.Email;
                    return;
                }
            }

            throw new Exception("Nincs meg a keresett eladó!\nNem lehet módosítani!");
        }
    }
}
