using IngatlanCentrum.Model;
using System.Collections.Generic;

namespace IngatlanCentrum.Service
{
    public class UgynokJogosultsagService
    {
        private Repository.Repository repository;

        public UgynokJogosultsagService()
        {
            repository = new Repository.Repository();
        }

        public List<UgynokJogosultsag> GetUgynokJogosultsagok()
        {
            return repository.GetUgynokKategoriak();
        }
    }
}
