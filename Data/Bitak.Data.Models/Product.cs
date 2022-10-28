namespace Bitak.Data.Models
{
    using Bitak.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
