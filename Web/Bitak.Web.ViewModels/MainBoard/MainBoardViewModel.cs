namespace Bitak.Web.ViewModels.MainBoard
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Bitak.Data.Models.Others;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Data.Models.PcComponents.Enums;
    using Bitak.Services.Mapping;
    using Bitak.Web.ViewModels.Settings;
    using Microsoft.EntityFrameworkCore;

    public class MainBoardViewModel : IMapFrom<MainBoard>, IHaveCustomMappings
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

        public ICollection<MbPort> Ports { get; set; }

        public ICollection<MbInterface> Interfaces { get; set; }

        public int? Waranty { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MainBoard, MainBoardViewModel>();
        }
    }
}
