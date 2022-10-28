namespace Bitak.Web.ViewModels.Product
{
    using AutoMapper;
    using Bitak.Data.Models;
    using Bitak.Services.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
