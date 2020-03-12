using System.Collections.Generic;
using IngatlanCentrum.Model;
using System;
using System.Diagnostics;
using System.Data;

namespace IngatlanCentrum.Repository
{
    /// <summary>
    /// Ingatlan állapotok adattár
    /// </summary>
    public partial class Repository
    {
        /// <summary>
        /// Ingatlan állapotokat tartalmazó lista
        /// </summary>
        private List<IngatlanAllapot> ingatlanAllapotok = new List<IngatlanAllapot>();

        /// <summary>
        /// Metódus, amely letölti az ingatlan állapotok adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az ingatlan állapotokat tartalmazó listába.
        /// </summary>
        private void LetoltIngatlanAllapotokatAdatbazisbol()
        {
            try
            {
                DataTable ingatlanAllapotTabla = adatbazis.DQL("SELECT * FROM ingatlan_allapotok;");

                foreach (DataRow row in ingatlanAllapotTabla.Rows)
                {
                    ingatlanAllapotok.Add(new IngatlanAllapot
                    {
                        Elnevezes = row[0].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                throw new Exception("Nem sikerült az ingatlan állapot adatok letöltése adatbázisból!");
            }
        }

        public List<IngatlanAllapot> GetIngatlanAllapotok()
        {
            return ingatlanAllapotok;
        }
    }
}
