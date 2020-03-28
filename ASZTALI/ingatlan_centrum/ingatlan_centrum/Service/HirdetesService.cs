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

        public void HozzaadHirdetes(Hirdetes hirdetes)
        {
            repository.HozzaadHirdetes(hirdetes);
        }

        public void ModositHirdetes(Hirdetes hirdetes)
        {
            repository.ModositHirdetes(hirdetes);
        }

        public List<Hirdetes> GetHirdetesek()
        {
            return repository.GetHirdetesek();
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
                    try
                    {
                        h.Aktiv = false;
                        repository.ModositHirdetes(h);
                        return;
                    }
                    catch (HirdetesException e)
                    {
                        throw new HirdetesException(e.Message);
                    }
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
                    repository.ModositHirdetes(h);
                    return;
                }
            }

            throw new HirdetesException("A hirdetés már aktív!");
        }

        public int GetNextHirdetesId()
        {
            return repository.GetMaxHirdetesID() + 1;
        }
    }
}
