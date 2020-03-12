using IngatlanCentrum.Model;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Repository
{
    /// <summary>
    /// Ingatlan adattár
    /// </summary>
    public partial class Repository
    {
        /// <summary>
        /// Ingatlanokat tartalmazó lista
        /// </summary>
        private List<Ingatlan> ingatlanok = new List<Ingatlan>();

        /// <summary>
        /// Metódus, amely letölti az ingatlanok adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az ingatlanokat tartalmazó listába.
        /// </summary>
        private void LetoltIngatlanokatAdatbazisbol()
        {
            try
            {
                DataTable ingatlanTabla = adatbazis.DQL("SELECT * FROM ingatlanok;");

                foreach (DataRow row in ingatlanTabla.Rows)
                {
                    ingatlanok.Add(new Ingatlan
                    {
                        HelyrajziSzam = row[0].ToString(),
                        Telepules = row[1].ToString(),
                        Alapterulet = Convert.ToInt32(row[2]),
                        Kategoria = row[3].ToString(),
                        Allapot = row[4].ToString(),
                        Elado = GetEladok().Find(x => x.Adoazonosito == row[5].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                throw new IngatlanException("Nem sikerült az ingatlan adatok letöltése adatbázisból!");
            }
        }

        public List<Ingatlan> GetIngatlanok()
        {
            return ingatlanok;
        }

        public void HozzaadIngatlan(Ingatlan ingatlan)
        {
            ingatlanok.Add(ingatlan);
        }

        public void ModositIngatlan(Ingatlan ingatlan)
        {
            foreach (Ingatlan i in ingatlanok)
            {
                if (i.HelyrajziSzam == ingatlan.HelyrajziSzam)
                {
                    i.Telepules = ingatlan.Telepules;
                    i.Alapterulet = ingatlan.Alapterulet;
                    i.Kategoria = ingatlan.Kategoria;
                    i.Allapot = ingatlan.Allapot;
                    i.Elado = ingatlan.Elado;
                    return;
                }
            }

            throw new Exception("Nincs meg a keresett ingatlan!\nNem lehet módosítani!");
        }
    }
}
