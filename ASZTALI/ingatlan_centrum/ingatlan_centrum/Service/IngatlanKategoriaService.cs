using System.Collections.Generic;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Ingatlan kategória szolgáltatások
    /// </summary>
    public class IngatlanKategoriaService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public IngatlanKategoriaService()
        {
            repository = new Repository.Repository();
        }

        public List<IngatlanKategoria> GetIngatlanKategoriak()
        {
            return repository.GetIngatlanKategoriak();
        }
    }
}
