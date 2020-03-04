﻿using System.Collections.Generic;
using IngatlanCentrum.Model;
using System;
using System.Diagnostics;
using System.Data;

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
        private List<IngatlanKategoria> ingatlanKategoriak;

        /// <summary>
        /// Metódus, amely letölti az ingatlan kategóriák adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az ingatlan kategóriákat tartalmazó listába.
        /// </summary>
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
                Debug.WriteLine($"{ex.Message}");
                throw new Exception("Nem sikerült az ingatlan kategória adatok letöltése adatbázisból!");
            }
        }

        public List<IngatlanKategoria> GetIngatlanKategoriak()
        {
            if (ingatlanKategoriak == null)
            {
                ingatlanKategoriak = new List<IngatlanKategoria>();
                LetoltIngatlanKategoriakatAdatbazisbol();
                return ingatlanKategoriak;
            }

            return ingatlanKategoriak;
        }
    }
}
