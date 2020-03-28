using System.Collections.Generic;
using IngatlanCentrum.Model;
using System;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Ingatlan szolgáltatások
    /// </summary>
    public class IngatlanService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public IngatlanService()
        {
            repository = new Repository.Repository();
        }

        public Ingatlan GetIngatlan(string helyrajziSzam)
        {
            foreach (Ingatlan ingatlan in repository.GetIngatlanok())
            {
                if (ingatlan.HelyrajziSzam == helyrajziSzam)
                {
                    return ingatlan;
                }
            }

            throw new IngatlanException("Nincs létezik ingatlan adott helyrajzi számmal!");
        }

        public List<Ingatlan> GetIngatlanok()
        {
            return repository.GetIngatlanok();
        }

        public void HozzaadIngatlan(Ingatlan ingatlan)
        {
            repository.HozzaadIngatlan(ingatlan);
        }

        public void ModositIngatlan(Ingatlan ingatlan)
        {
            repository.ModositIngatlan(ingatlan);
        }

        public void ModositEladotIngatlanban(string adoazonostio, Elado elado)
        {
            foreach (Ingatlan ingatlan in GetIngatlanok())
            {
                if (ingatlan.Elado.Adoazonosito == adoazonostio)
                {
                    ingatlan.Elado = elado;
                }
            }
        }
    }
}
