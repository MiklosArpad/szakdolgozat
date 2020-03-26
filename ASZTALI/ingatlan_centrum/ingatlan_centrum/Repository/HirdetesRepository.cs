using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace IngatlanCentrum.Repository
{
    public partial class Repository
    {
        /// <summary>
        /// Hirdetéseket tartalmazó lista
        /// </summary>
        private List<Hirdetes> hirdetesek = new List<Hirdetes>();

        /// <summary>
        /// Metódus, amely letölti a hirdetések adatait az adatbázisból és objektumokat képez belőle.
        /// Az objektumokat elmenti a hirdetéseket tartalmazó listába.
        /// </summary>
        private void LetoltHirdeteseketAdatbazisbol()
        {
            try
            {
                DataTable hirdetesekTabla = adatbazis.DQL("SELECT * FROM hirdetesek;");

                foreach (DataRow row in hirdetesekTabla.Rows)
                {
                    hirdetesek.Add(new Hirdetes
                    {
                        Id = Convert.ToInt32(row[0]),
                        Cim = row[1].ToString(),
                        Leiras = row[2].ToString(),
                        Ar = Convert.ToInt32(row[3]),
                        Ingatlan = GetIngatlanok().Find(x => x.HelyrajziSzam == row[4].ToString()),
                        Ugynok = GetUgynokok().Find(x => x.Id == row[5].ToString()),
                        Datum = Convert.ToDateTime(row[6]).ToString("yyyy-MM-dd hh:mm:ss"),
                        Aktiv = Convert.ToBoolean(row[7])
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new HirdetesException("Nem sikerült a hirdetés adatok letöltése adatbázisból!");
            }
        }

        /// <summary>
        /// Hirdetések lista getter.
        /// </summary>
        public List<Hirdetes> GetHirdetesek()
        {
            return hirdetesek;
        }

        /// <summary>
        /// Hirdetés hozzáadása listához és adatbázishoz.
        /// </summary>
        /// <param name="hirdetes">Hirdetés objektum</param>
        /// <exception cref="HirdetesException"></exception>
        public void HozzaadHirdetes(Hirdetes hirdetes)
        {
            try
            {
                string aktiv = "0";

                if (hirdetes.Aktiv)
                {
                    aktiv = "1";
                }

                adatbazis.DML($"INSERT INTO hirdetesek (azonosito, cim, leiras, ar, ingatlan, ugynok, hirdetes_datuma, aktiv) " +
                    $"VALUES (\"{hirdetes.Id}\", \"{hirdetes.Cim}\", \"{hirdetes.Leiras}\", \"{hirdetes.Ar}\", " +
                    $"\"{hirdetes.Ingatlan.HelyrajziSzam}\", \"{hirdetes.Ugynok.Id}\", \"{hirdetes.Datum}\", \"{aktiv}\");");
                hirdetesek.Add(hirdetes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new EladoException("Nem sikerült a hirdetés hozzáadása!");
            }
        }

        /// <summary>
        /// Hirdetés módosítása listában és adatbázisban.
        /// </summary>
        /// <param name="hirdetes">Hirdetés objektum</param>
        /// <exception cref="HirdetesException"></exception>
        public void ModositHirdetes(Hirdetes hirdetes)
        {
            foreach (Hirdetes h in hirdetesek)
            {
                if (h.Id == hirdetes.Id)
                {
                    try
                    {
                        string aktiv = "0";

                        if (hirdetes.Aktiv)
                        {
                            aktiv = "1";
                        }

                        adatbazis.DML($"UPDATE hirdetesek SET cim = \"{hirdetes.Cim}\", " +
                            $"leiras = \"{hirdetes.Leiras}\", " +
                            $"ar = \"{hirdetes.Ar}\", " +
                            $"ingatlan = \"{hirdetes.Ingatlan.HelyrajziSzam}\", " +
                            $"aktiv = \"{aktiv}\"" +
                            $"WHERE azonosito = \"{hirdetes.Id}\";");

                        h.Cim = hirdetes.Cim;
                        h.Leiras = hirdetes.Leiras;
                        h.Ar = hirdetes.Ar;
                        return;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw new HirdetesException("Nem sikerült a hirdetés módosítása!");
                    }
                }
            }

            throw new HirdetesException("Nincs meg a keresett hirdetés!\nNem lehet módosítani!");
        }

        /// <summary>
        /// Legnagyobb hirdetés azonosító meghatározása adatbázis alapján.
        /// </summary>
        public int GetMaxHirdetesID()
        {
            int maxId = 1;

            try
            {
                string maxIdFromDatabase = adatbazis.ScalarDQL("SELECT MAX(hirdetesek.azonosito) FROM hirdetesek;");
                int.TryParse(maxIdFromDatabase, out maxId);
                return maxId;
            }
            catch (Exception)
            {
                return maxId;
            }
        }
    }
}
