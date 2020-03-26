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
        /// <exception cref="IngatlanException"></exception>
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
                Debug.WriteLine(ex.Message);
                throw new IngatlanException("Nem sikerült az ingatlan adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Ingatlan lista getter.
        /// </summary>
        public List<Ingatlan> GetIngatlanok()
        {
            return ingatlanok;
        }

        /// <summary>
        /// Ingatlan hozzáadása listához és adatbázishoz.
        /// </summary>
        /// <param name="ingatlan">ingatlan objektum</param>
        /// <exception cref="IngatlanException"></exception>
        public void HozzaadIngatlan(Ingatlan ingatlan)
        {
            try
            {
                adatbazis.DML($"INSERT INTO ingatlanok (helyrajzi_szam, telepules, alapterulet, kategoria, allapot, elado) " +
                    $"VALUES (\"{ingatlan.HelyrajziSzam}\", \"{ingatlan.Telepules}\", \"{ingatlan.Alapterulet}\", \"{ingatlan.Kategoria}\", " +
                    $"\"{ingatlan.Allapot}\", \"{ingatlan.Elado.Adoazonosito}\");");
                ingatlanok.Add(ingatlan);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new IngatlanException("Nem sikerült az ingatlan hozzáadása!");
            }
        }

        /// <summary>
        /// Ingatlan módosítása listában és adatbázisban.
        /// </summary>
        /// <param name="ingatlan">Ingatlan objektum</param>
        /// <exception cref="IngatlanException"></exception>
        public void ModositIngatlan(Ingatlan ingatlan)
        {
            foreach (Ingatlan i in ingatlanok)
            {
                if (i.HelyrajziSzam == ingatlan.HelyrajziSzam)
                {
                    try
                    {
                        adatbazis.DML($"UPDATE ingatlanok SET telepules = \"{ingatlan.Telepules}\", " +
                            $"alapterulet = \"{ingatlan.Alapterulet}\", " +
                            $"kategoria = \"{ingatlan.Kategoria}\", " +
                            $"allapot = \"{ingatlan.Allapot}\"," +
                            $"elado = \"{ingatlan.Elado.Adoazonosito}\" " +
                            $"WHERE helyrajzi_szam = \"{ingatlan.HelyrajziSzam}\";");

                        i.Telepules = ingatlan.Telepules;
                        i.Alapterulet = ingatlan.Alapterulet;
                        i.Kategoria = ingatlan.Kategoria;
                        i.Allapot = ingatlan.Allapot;
                        i.Elado = ingatlan.Elado;
                        return;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw new IngatlanException("");
                    }
                }
            }

            throw new IngatlanException("Nincs meg a keresett ingatlan!\nNem lehet módosítani!");
        }
    }
}
