using IngatlanCentrum.Model;
using System;
using System.Collections.Generic;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Hirdetés szolgáltatás
    /// </summary>
    public class HirdetesService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public HirdetesService()
        {
            repository = new Repository.Repository();
        }

        public List<Hirdetes> GetHirdetesek()
        {
            return repository.GetHirdetesek();
        }

        public Ingatlan GetHirdetettIngatlanHelyrajziSzamAlapjan(string helyrajziSzam)
        {
            foreach (Hirdetes hirdetes in repository.GetHirdetesek())
            {
                if (hirdetes.Ingatlan.HelyrajziSzam == helyrajziSzam)
                {
                    return hirdetes.Ingatlan;
                }
            }

            throw new Exception("A keresett helyrajzi számmal nincs ingatlan meghirdetve!");
        }

        public List<Hirdetes> GetHirdetettIngatlanokUgynokSzerint(string ugynokAzonosito)
        {
            List<Hirdetes> hirdetettIngatlanokUgynokSzerint = new List<Hirdetes>();

            foreach (Hirdetes hirdetes in GetHirdetesek())
            {
                if (hirdetes.Ugynok.Id == ugynokAzonosito)
                {
                    hirdetettIngatlanokUgynokSzerint.Add(hirdetes);
                }
            }

            hirdetettIngatlanokUgynokSzerint.Sort();

            return hirdetettIngatlanokUgynokSzerint;
        }
    }
}
