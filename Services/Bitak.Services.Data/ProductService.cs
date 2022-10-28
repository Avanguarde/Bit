namespace Bitak.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models;
    using Bitak.Services.Mapping;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;

        public ProductService(IDeletableEntityRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public int GetCount()
        {
            return this.productRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.productRepository.All().To<T>().ToList();
        }
    }
}
