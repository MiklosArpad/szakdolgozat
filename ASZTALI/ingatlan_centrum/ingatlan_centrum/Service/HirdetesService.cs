using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;
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

            throw new HirdetesException("A keresett helyrajzi számmal nincs ingatlan meghirdetve!");
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

        public bool IngatlanSzerepelEHirdetesben(string helyrajziSzam)
        {
            foreach (Hirdetes hirdetes in GetHirdetesek())
            {
                if (hirdetes.Ingatlan.HelyrajziSzam == helyrajziSzam)
                {
                    return true;
                }
            }

            return false;
        }

        public Hirdetes GetHirdetes(string helyrajziSzam)
        {
            foreach (Hirdetes hirdetes in GetHirdetesek())
            {
                if (hirdetes.Ingatlan.HelyrajziSzam == helyrajziSzam)
                {
                    return hirdetes;
                }
            }

            throw new IngatlanException($"Nincs hirdetés az alábbi helyrajzi számmal:\n{helyrajziSzam}");
        }

        public Hirdetes GetHirdetes(int azonosito)
        {
            foreach (Hirdetes hirdetes in GetHirdetesek())
            {
                if (hirdetes.Id == azonosito)
                {
                    return hirdetes;
                }
            }

            throw new IngatlanException($"Nincs hirdetés az alábbi azonosítóval: \n{azonosito}");
        }

        public void HirdetesDeaktivalas(Hirdetes hirdetes)
        {
            foreach (Hirdetes h in GetHirdetesek())
            {
                if (h.Id == hirdetes.Id && h.Aktiv == true)
                {
                    h.Aktiv = false;
                    return;
                }
            }

            throw new HirdetesException("A hirdetés már deaktív!");
        }

        public void HirdetesAktivalas(Hirdetes hirdetes)
        {
            foreach (Hirdetes h in GetHirdetesek())
            {
                if (h.Id == hirdetes.Id && h.Aktiv == false)
                {
                    h.Aktiv = true;
                    return;
                }
            }

            throw new HirdetesException("A hirdetés már aktív!");
        }
    }
}
