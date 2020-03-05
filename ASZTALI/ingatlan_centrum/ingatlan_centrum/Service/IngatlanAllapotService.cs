using System.Collections.Generic;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Ingatlan állapot szolgáltatások
    /// </summary>
    public class IngatlanAllapotService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
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
