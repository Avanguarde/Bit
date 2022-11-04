namespace Bitak.Data.Models.PcComponents
{
    using System.ComponentModel.DataAnnotations;

    using Bitak.Data.Common.Models;
    using Bitak.Data.Models.PcComponents.Enums;
    using Microsoft.EntityFrameworkCore;

    public class MainBoard : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Brand { get; set; }

        [Required]
        [Precision(14, 2)]
        public decimal Price { get; set; }

        [Required]
        public ProcessorSocket Socket { get; set; }

        [Required]
        public MbChipset Chipset { get; set; }

        [Required]
        public FormFactor FormFactor { get; set; }

        [Required]
        public MemoryType MemoryType { get; set; }

        public int MemorySlots { get; set; }

        public string Ports { get; set; }

        public string Interfaces { get; set; }

        public int? Waranty { get; set; }
    }
}
