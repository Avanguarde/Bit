namespace Bitak.Web.Controllers
{
    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models;
    using Bitak.Services.Data;
    using Bitak.Web.ViewModels.Product;
    using Bitak.Web.ViewModels.Settings;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Threading.Tasks;
    using System;
    using System.Linq;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IDeletableEntityRepository<Product> repository;

        public ProductController(IProductService productService, IDeletableEntityRepository<Product> repository)
        {
            this.productService = productService;
            this.repository = repository;
        } 

        public IActionResult Index()
        {
            var productList = this.productService.GetAll<ProductViewModel>();
            var model = productList.FirstOrDefault();
            return this.View(model);
        }

        public async Task<IActionResult> InsertProduct()
        {
            var random = new Random();
            var des = Guid.NewGuid();
            var product = new Product { Name = $"Nm_{random.Next()}", Description = $"Dscrptn_{des}" };

            await this.repository.AddAsync(product);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
