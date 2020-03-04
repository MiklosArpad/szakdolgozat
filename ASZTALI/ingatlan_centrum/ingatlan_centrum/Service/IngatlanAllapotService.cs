using System.Collections.Generic;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Service
{
    public class IngatlanAllapotService
    {
        private Repository.Repository repository;

        public IngatlanAllapotService()
        {
            repository = new Repository.Repository();
        }

        public List<IngatlanAllapot> GetIngatlanAllapotok()
        {
            return repository.GetIngatlanAllapotok();
        }
    }
}
