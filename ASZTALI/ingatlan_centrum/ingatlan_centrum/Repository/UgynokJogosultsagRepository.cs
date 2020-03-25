using System.Collections.Generic;
using IngatlanCentrum.Model;
using System;
using System.Diagnostics;
using System.Data;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Repository
{
    /// <summary>
    /// Ügynök jogosultságok adattár
    /// </summary>
    public partial class Repository
    {
        /// <summary>
        /// Ügynök kategóriákat tartalmazó lista
        /// </summary>
        private List<UgynokJogosultsag> ugynokJogosultsagok = new List<UgynokJogosultsag>();

        /// <summary>
        /// Metódus, amely letölti az ügynök jogosultságok adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az ügynök jogosultságok tartalmazó listába.
        /// </summary>
        /// <exception cref="UgynokJogosultsagException"></exception>
        private void LetoltUgynokJogosultsagokatAdatbazisbol()
        {
            try
            {
                DataTable ugynokJogosultsagTabla = adatbazis.DQL("SELECT * FROM ugynok_jogosultsagok;");

                foreach (DataRow row in ugynokJogosultsagTabla.Rows)
                {
                    ugynokJogosultsagok.Add(new UgynokJogosultsag
                    {
                        Elnevezes = row[0].ToString(),
                        Leiras = row[1].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new UgynokJogosultsagException("Nem sikerült az ügynök jogosultság adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Ügynök jogosultságok lista getter.
        /// </summary>
        public List<UgynokJogosultsag> GetUgynokJogosultsagok()
        {
            return ugynokJogosultsagok;
        }
    }
}
