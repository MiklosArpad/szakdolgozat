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
        /// 
        /// </summary>
        /// <param name="hirdetes"></param>
        public void HozzaadHirdetes(Hirdetes hirdetes)
        {
            hirdetesek.Add(hirdetes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hirdetes"></param>
        public void ModositHirdetes(Hirdetes hirdetes)
        {
            foreach (Hirdetes h in hirdetesek)
            {
                if (h.Id == hirdetes.Id)
                {
                    h.Cim = hirdetes.Cim;
                    h.Leiras = hirdetes.Leiras;
                    h.Ar = hirdetes.Ar;
                    h.Ingatlan = hirdetes.Ingatlan;
                    h.Ugynok = hirdetes.Ugynok;
                    h.Datum = hirdetes.Datum;
                    h.Aktiv = hirdetes.Aktiv;
                    return;
                }
            }

            throw new HirdetesException("Nincs meg a keresett hirdetés!\nNem lehet módosítani!");
        }

        /// <summary>
        /// 
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
