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
        /// Ügynököket tartalmazó lista
        /// </summary>
        private List<Ugynok> ugynokok = new List<Ugynok>();

        /// <summary>
        /// Metódus, amely letölti az ügynökök adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti az ügynököket tartalmazó listába.
        /// </summary>
        /// <exception cref="UgynokException"></exception>
        private void LetoltUgynokoketAdatbazisbol()
        {
            try
            {
                DataTable ugynokTabla = adatbazis.DQL("SELECT * FROM ugynokok;");

                foreach (DataRow row in ugynokTabla.Rows)
                {
                    ugynokok.Add(new Ugynok
                    {
                        Id = row[0].ToString(),
                        Jelszo = row[1].ToString(),
                        Vezeteknev = row[2].ToString(),
                        Keresztnev = row[3].ToString(),
                        Telefonszam = row[4].ToString(),
                        Jogosultsag = row[5].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new UgynokException("Nem sikerült az ügynök adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Ügynökök lista getter.
        /// </summary>
        public List<Ugynok> GetUgynokok()
        {
            return ugynokok;
        }

        /// <summary>
        /// Ügynök hozzáadása listához és adatbázishoz.
        /// </summary>
        /// <param name="ugynok">Ügynök objektum</param>
        /// <exception cref="UgynokException"></exception>
        public void HozzaadUgynok(Ugynok ugynok)
        {
            try
            {
                adatbazis.DML($"INSERT INTO ugynokok (azonosito, jelszo, vezeteknev, keresztnev, telefonszam, jogosultsag) " +
                    $"VALUES (\"{ugynok.Id}\", \"{ugynok.Jelszo}\", \"{ugynok.Vezeteknev}\", \"{ugynok.Keresztnev}\", " +
                    $"\"{ugynok.Telefonszam}\", \"{ugynok.Jogosultsag}\");");
                ugynokok.Add(ugynok);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new EladoException("Nem sikerült az eladó hozzáadása!");
            }
        }

        /// <summary>
        /// Ügynök módosítása listában és adatbázisban.
        /// </summary>
        /// <param name="ugynok">Ügynök objektum</param>
        /// <exception cref="UgynokException"></exception>
        public void ModositUgynok(Ugynok ugynok)
        {
            foreach (Ugynok u in ugynokok)
            {
                if (u.Id == ugynok.Id)
                {
                    adatbazis.DML($"UPDATE ugynokok SET jelszo = \"{ugynok.Jelszo}\", " +
                        $"vezeteknev = \"{ugynok.Vezeteknev}\", " +
                        $"keresztnev = \"{ugynok.Keresztnev}\", " +
                        $"telefonszam = \"{ugynok.Telefonszam}\", " +
                        $"jogosultsag = \"{ugynok.Jogosultsag}\" " +
                        $"WHERE azonosito = \"{ugynok.Id}\";");

                    u.Jelszo = ugynok.Jelszo;
                    u.Vezeteknev = ugynok.Vezeteknev;
                    u.Keresztnev = ugynok.Keresztnev;
                    u.Telefonszam = ugynok.Telefonszam;
                    u.Jogosultsag = ugynok.Jogosultsag;
                    return;
                }
            }

            throw new UgynokException("Nincs meg a keresett ügynök!\nNem lehet módosítani!");
        }
    }
}
