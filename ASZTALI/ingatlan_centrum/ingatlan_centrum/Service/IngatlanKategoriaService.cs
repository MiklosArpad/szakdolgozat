using System.Collections.Generic;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Service
{
    public class IngatlanKategoriaService
    {
        private Repository.Repository repository;

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
