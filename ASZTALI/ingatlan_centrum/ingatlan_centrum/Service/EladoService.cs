using System;
using System.Collections.Generic;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Service
{
    public class EladoService
    {
        private Repository.Repository repository;

        public EladoService()
        {
            repository = new Repository.Repository();
        }

        public Elado GetEladoAdoszamAlapjan(int adoszam)
        {
            foreach (Elado elado in repository.GetEladok())
            {
                if (elado.Adoszam == adoszam)
                {
                    return elado;
                }
            }

            throw new Exception("Ilyen adószámmal nem létezik eladó!");
        }

        public List<Elado> GetEladok()
        {
            return repository.GetEladok();
        }

        public List<Elado> GetEladoTelepulesSzerint(string telepulesNev)
        {
            List<Elado> eladokTelepulesSzerint = new List<Elado>();

            foreach (Elado elado in GetEladok())
            {
                if (elado.Telepules == telepulesNev)
                {
                    eladokTelepulesSzerint.Add(elado);
                }
            }

            eladokTelepulesSzerint.Sort();

            return eladokTelepulesSzerint;
        }

        public void HozzaadElado(Elado elado)
        {
            repository.HozzaadElado(elado);
        }

        public void ModositElado(Elado elado)
        {
            repository.ModositElado(elado);
        }
    }
}
