namespace Bitak.Web.ViewModels.MainBoard
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Bitak.Data.Models.PcComponents;
    using Bitak.Data.Models.PcComponents.Enums;
    using Bitak.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class MainBoardViewModel : IMapFrom<MainBoard>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage ="Name must be from 10 to 200 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Brand is required!")]
        public Brand Brand { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Precision(14, 2)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Socket is required")]
        public ProcessorSocket Socket { get; set; }

        [Required(ErrorMessage = "Chipset is required")]
        public MbChipset Chipset { get; set; }

        [Required(ErrorMessage = "Form factor is required")]
        public FormFactor FormFactor { get; set; }

        [Required(ErrorMessage = "Memory type is required")]
        public MemoryType MemoryType { get; set; }

        public int MemorySlots { get; set; }

        public string Ports { get; set; }

        public string Interfaces { get; set; }

        public int? Waranty { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MainBoard, MainBoardViewModel>();
        }
    }
}
