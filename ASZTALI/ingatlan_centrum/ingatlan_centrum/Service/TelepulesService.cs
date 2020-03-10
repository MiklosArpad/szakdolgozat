using IngatlanCentrum.Model;
using System.Linq;
using System.Collections.Generic;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Település szolgáltatások
    /// </summary>
    public class TelepulesService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public TelepulesService()
        {
            repository = new Repository.Repository();
        }

        public Telepules GetTelepules(string telepulesNev)
        {
            foreach (Telepules telepules in GetTelepulesek())
            {
                if (telepules.Nev == telepulesNev)
                {
                    return telepules;
                }
            }

            throw new TelepulesException("Ilyen nevű település nem létezik!");
        }

        public List<Telepules> GetTelepulesek()
        {
            return repository.GetTelepulesek();
        }

        public List<Telepules> GetTelepulesKezdobetuAlapjan(char kezdobetu)
        {
            List<Telepules> telepulesKezdobetuAlapjan = new List<Telepules>();

            foreach (Telepules telepules in GetTelepulesek())
            {
                if (telepules.Nev.ElementAt(0) == kezdobetu)
                {
                    telepulesKezdobetuAlapjan.Add(telepules);
                }
            }

            telepulesKezdobetuAlapjan.Sort();

            return telepulesKezdobetuAlapjan;
        }
    }
}
