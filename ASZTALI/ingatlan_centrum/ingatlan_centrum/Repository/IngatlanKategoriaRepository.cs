using System.Collections.Generic;
using IngatlanCentrum.Model;
using System;
using System.Diagnostics;
using System.Data;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Repository
{
    /// <summary>
    /// Ingatlan kategóriák adattár
    /// </summary>
    public partial class Repository
    {
        /// <summary>
        /// Ingatlan kategóriákat tartalmazó lista
        /// </summary>
        private List<IngatlanKategoria> ingatlanKategoriak = new List<IngatlanKategoria>();

        /// <summary>
        /// Metódus, amely letölti az ingatlan kategóriák adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az ingatlan kategóriákat tartalmazó listába.
        /// </summary>
        /// <exception cref="IngatlanKategoriaException"></exception>
        private void LetoltIngatlanKategoriakatAdatbazisbol()
        {
            try
            {
                DataTable ingatlanKategoriaTabla = adatbazis.DQL("SELECT * FROM ingatlan_kategoriak;");

                foreach (DataRow row in ingatlanKategoriaTabla.Rows)
                {
                    ingatlanKategoriak.Add(new IngatlanKategoria
                    {
                        Elnevezes = row[0].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new IngatlanKategoriaException("Nem sikerült az ingatlan kategória adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Ingatlan kategória lista getter.
        /// </summary>
        public List<IngatlanKategoria> GetIngatlanKategoriak()
        {
            return ingatlanKategoriak;
        }
    }
}
