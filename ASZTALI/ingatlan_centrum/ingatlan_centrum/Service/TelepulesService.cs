using IngatlanCentrum.Model;
using System.Linq;
using System.Collections.Generic;
using System;

namespace IngatlanCentrum.Service
{
    public class TelepulesService
    {
        private Repository.Repository repository;

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

            throw new Exception("Ilyen nevű település nem létezik!");
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
