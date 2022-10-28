namespace Bitak.Data.Models.PcComponents
{
    using System.ComponentModel.DataAnnotations;

    using Bitak.Data.Common.Models;
    using Bitak.Data.Models.PcComponents.Enums;
    using Microsoft.EntityFrameworkCore;

    internal class Processor : BaseModel<int>
    {
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Brand { get; set; }

        public int? TDP { get; set; }

        [Required]
        [Precision(3, 2)]
        public decimal Price { get; set; }

        public ProcessorSocket Socket { get; set; }

        [Precision(3, 2)]
        public float Frequency { get; set; }

        [Precision(3, 2)]
        public float TurboBoost { get; set; }

        public int PhisicalCores { get; set; }

        public int LogicalCores { get; set; }

        public int Cache { get; set; }

        public Graphics Graphics { get; set; }
    }
}
