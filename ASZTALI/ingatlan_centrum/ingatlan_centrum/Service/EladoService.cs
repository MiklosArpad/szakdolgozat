using System;
using System.Collections.Generic;
using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Eladó szolgáltatások
    /// </summary>
    public class EladoService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public EladoService()
        {
            repository = new Repository.Repository();
        }

        /// <summary>
        /// Függvény, ami visszaad egy eladót keresett adóazonosító szerint
        /// </summary>
        /// <param name="adoazonosito">Adóazonosító</param>
        /// <returns>Keresett adószámú eladó</returns>
        /// <exception cref="Exception">Amennyiben nem talál a keresett adóazonosító alapján eladót a függvény,
        /// kivétel képződik</exception>
        public Elado GetEladoAdoazonositoAlapjan(string adoazonosito)
        {
            foreach (Elado elado in repository.GetEladok())
            {
                if (elado.Adoazonosito == adoazonosito)
                {
                    return elado;
                }
            }

            throw new EladoException("Nem található eladó a keresett adóazonosítóval!");
        }

        /// <summary>
        /// Függvény, amely visszaadja az adattárból az eladók listáját
        /// </summary>
        /// <returns>Minden eladó listában</returns>
        public List<Elado> GetEladok()
        {
            return repository.GetEladok();
        }

        public Elado GetElado(string teljesNev)
        {
            string[] nev = teljesNev.Split(' ');

            foreach (Elado elado in GetEladok())
            {
                if (elado.Vezeteknev == nev[0] && elado.Keresztnev == nev[1])
                {
                    return elado;
                }
            }

            throw new EladoException("Nincs ilyen nevű eladó!");
        }

        /// <summary>
        /// Eladó hozzáadása az adattár eladók listájához és az adatbázishoz
        /// </summary>
        /// <param name="elado">Eladó</param>
        public void HozzaadElado(Elado elado)
        {
            repository.HozzaadElado(elado);
        }

        /// <summary>
        /// Eladó módosítása az adattár eladók listájában és adatbázisban
        /// </summary>
        /// <param name="elado">Eladó</param>
        public void ModositElado(Elado elado)
        {
            repository.ModositElado(elado);
        }
    }
}
