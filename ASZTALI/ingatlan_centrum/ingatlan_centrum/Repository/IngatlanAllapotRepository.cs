using System.Collections.Generic;
using IngatlanCentrum.Model;
using System;
using System.Diagnostics;
using System.Data;
using IngatlanCentrum.Exceptions;

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
        /// <exception cref="IngatlanAllapotException"></exception>
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
                Debug.WriteLine(ex.Message);
                throw new IngatlanAllapotException("Nem sikerült az ingatlan állapot adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Ingatlan állapot lista getter.
        /// </summary>
        public List<IngatlanAllapot> GetIngatlanAllapotok()
        {
            return ingatlanAllapotok;
        }
    }
}
