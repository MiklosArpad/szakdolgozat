using IngatlanCentrum.Model;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Repository
{
    public partial class Repository
    {
        /// <summary>
        /// Településeket tartalmazó lista
        /// </summary>
        private List<Telepules> telepulesek = new List<Telepules>();

        /// <summary>
        /// Metódus, amely letölti a települések adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti a településeket tartalmazó listába.
        /// </summary>
        /// <exception cref="TelepulesException"></exception>
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
                Debug.WriteLine(ex.Message);
                throw new TelepulesException("Nem sikerült a település adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Települések lista getter.
        /// </summary>
        public List<Telepules> GetTelepulesek()
        {
            return telepulesek;
        }
    }
}
