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
        /// Településeket tartalmazó lista
        /// </summary>
        private List<Telepules> telepulesek;

        /// <summary>
        /// Metódus, amely letölti a települések adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti a településeket tartalmazó listába.
        /// </summary>
        private void LetoltTelepuleseketAdatbazisbol()
        {
            try
            {
                DataTable telepulesTabla = adatbazis.DQL("SELECT * FROM telepulesek;");

                foreach (DataRow row in telepulesTabla.Rows)
                {
                    telepulesek.Add(new Telepules
                    {
                        Nev = row[0].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                throw new Exception("Nem sikerült a település adatok letöltése adatbázisból!");
            }
        }

        public List<Telepules> GetTelepulesek()
        {
            if (telepulesek == null)
            {
                telepulesek = new List<Telepules>();
                LetoltTelepuleseketAdatbazisbol();
                return telepulesek;
            }

            return telepulesek;
        }
    }
}
