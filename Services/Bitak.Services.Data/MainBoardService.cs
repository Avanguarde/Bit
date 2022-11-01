namespace Bitak.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Services.Mapping;

    public class MainBoardService : IMainBoardService
    {
        private readonly IDeletableEntityRepository<MainBoard> delitableRepository;

        public MainBoardService(IDeletableEntityRepository<MainBoard> delitableRepository)
        {
            this.delitableRepository = delitableRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.delitableRepository.All().To<T>().ToList();
        }

        public int GetCount()
        {
            var count = this.delitableRepository.All().Count();
            return count;
        }
    }
}
