using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

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
        private List<Elado> eladok = new List<Elado>();

        /// <summary>
        /// Metódus, amely letölti az eladók adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az eladókat tartalmazó listába.
        /// </summary>
        /// <exception cref="EladoException"></exception>
        private void LetoltEladokatAdatbazisbol()
        {
            try
            {
                DataTable eladoTabla = adatbazis.DQL("SELECT * FROM eladok;");

                foreach (DataRow row in eladoTabla.Rows)
                {
                    eladok.Add(new Elado
                    {
                        Adoazonosito = row[0].ToString(),
                        Vezeteknev = row[1].ToString(),
                        Keresztnev = row[2].ToString(),
                        Telepules = row[3].ToString(),
                        Lakcim = row[4].ToString(),
                        Telefonszam = row[5].ToString(),
                        Email = row[6].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new EladoException("Nem sikerült az eladó adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Eladók lista getter
        /// </summary>
        public List<Elado> GetEladok()
        {
            return eladok;
        }

        /// <summary>
        /// Eladó hozzáadása listához és adatbázishoz.
        /// </summary>
        /// <param name="elado">Eladó objektum</param>
        /// <exception cref="EladoException"></exception>
        public void HozzaadElado(Elado elado)
        {
            try
            {
                adatbazis.DML($"INSERT INTO eladok (adoazonosito, vezeteknev, keresztnev, telepules, lakcim, telefonszam, email) " +
                    $"VALUES (\"{elado.Adoazonosito}\", \"{elado.Vezeteknev}\", \"{elado.Keresztnev}\", \"{elado.Telepules}\", " +
                    $"\"{elado.Lakcim}\", \"{elado.Telefonszam}\", \"{elado.Email}\");");
                eladok.Add(elado);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new EladoException("Nem sikerült az eladó hozzáadása!");
            }
        }

        /// <summary>
        /// Eladó módosítása listában és adatbázisban.
        /// </summary>
        /// <param name="elado">Eladó objektum</param>
        /// <exception cref="EladoException"></exception>
        public void ModositElado(Elado elado)
        {
            foreach (Elado e in eladok)
            {
                if (e.Adoazonosito == elado.Adoazonosito)
                {
                    try
                    {
                        adatbazis.DML($"UPDATE eladok SET vezeteknev = \"{elado.Vezeteknev}\", " +
                            $"keresztnev = \"{elado.Keresztnev}\", " +
                            $"telepules = \"{elado.Telepules}\", " +
                            $"lakcim = \"{elado.Lakcim}\"," +
                            $"telefonszam = \"{elado.Telefonszam}\", " +
                            $"email = \"{elado.Email}\" " +
                            $"WHERE adoazonosito = \"{elado.Adoazonosito}\";");

                        e.Vezeteknev = elado.Vezeteknev;
                        e.Keresztnev = elado.Keresztnev;
                        e.Telepules = elado.Telepules;
                        e.Lakcim = elado.Lakcim;
                        e.Telefonszam = elado.Telefonszam;
                        e.Email = elado.Email;
                        return;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw new EladoException("Nem sikerült az eladó módosítása!");
                    }
                }
            }

            throw new EladoException("Nincs meg a keresett eladó!\nNem lehet módosítani!");
        }
    }
}
