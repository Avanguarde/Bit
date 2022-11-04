namespace Bitak.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Services.Mapping;
    using Bitak.Web.ViewModels.MainBoard;

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

        public MainBoard MakeModel(MainBoardViewModel viewModel)
        {
            var mainBoard = new MainBoard()
            {
                Brand = viewModel.Brand,
                Name = viewModel.Name,
                Chipset = viewModel.Chipset,
                FormFactor = viewModel.FormFactor,
                Interfaces = viewModel.Interfaces,
                MemorySlots = viewModel.MemorySlots,
                MemoryType = viewModel.MemoryType,
                Ports = viewModel.Ports,
                Socket = viewModel.Socket,
                Price = viewModel.Price,
                Waranty = viewModel.Waranty,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            return mainBoard;
        }
    }
}
