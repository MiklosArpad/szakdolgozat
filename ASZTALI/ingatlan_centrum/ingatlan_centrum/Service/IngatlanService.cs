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

            throw new IngatlanException("Ilyen leírással nem létezik ingatlan!");
        }

        public List<Ingatlan> GetIngatlan(int alapterulet)
        {
            List<Ingatlan> ingatlanokAlapteruletSzerint = new List<Ingatlan>();

            foreach (Ingatlan ingatlan in repository.GetIngatlanok())
            {
                if (ingatlan.Alapterulet == alapterulet)
                {
                    ingatlanokAlapteruletSzerint.Add(ingatlan);
                }
            }

            ingatlanokAlapteruletSzerint.Sort();

            return ingatlanokAlapteruletSzerint;
        }

        public List<Ingatlan> GetIngatlanok()
        {
            return repository.GetIngatlanok();
        }

        public List<Ingatlan> GetIngatlanokAlapteruletekKozott(int minAlapterulet, int maxAlapterulet)
        {
            List<Ingatlan> ingatlanokAlapteruletSzerint = new List<Ingatlan>();

            foreach (Ingatlan ingatlan in GetIngatlanok())
            {
                if (ingatlan.Alapterulet >= minAlapterulet && ingatlan.Alapterulet <= maxAlapterulet)
                {
                    ingatlanokAlapteruletSzerint.Add(ingatlan);
                }
            }

            ingatlanokAlapteruletSzerint.Sort();

            return ingatlanokAlapteruletSzerint;
        }

        public List<Ingatlan> GetIngatlanokEladoSzerint(string vezeteknev, string keresztnev)
        {
            List<Ingatlan> ingatlanokEladoSzerint = new List<Ingatlan>();

            foreach (Ingatlan ingatlan in GetIngatlanok())
            {
                if (ingatlan.Tulajdonos.Vezeteknev == vezeteknev && ingatlan.Tulajdonos.Keresztnev == keresztnev)
                {
                    ingatlanokEladoSzerint.Add(ingatlan);
                }
            }

            return ingatlanokEladoSzerint;
        }

        public List<Ingatlan> GetIngatlanokTelepulesSzerint(string telepulesNev)
        {
            List<Ingatlan> ingatlanokTelepulesSzerint = new List<Ingatlan>();

            foreach (Ingatlan ingatlan in GetIngatlanok())
            {
                if (ingatlan.Telepules == telepulesNev)
                {
                    ingatlanokTelepulesSzerint.Add(ingatlan);
                }
            }

            return ingatlanokTelepulesSzerint;
        }

        public void HozzaadIngatlan(Ingatlan ingatlan)
        {
            repository.HozzaadIngatlan(ingatlan);
        }

        public void ModositIngatlan(Ingatlan ingatlan)
        {
            repository.ModositIngatlan(ingatlan);
        }
    }
}
