using Bitak.Data.Models.PcComponents.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bitak.Web.ViewModels.SideBar
{
    public class SideBarViewModel
    {
        public Brand Brand { get; set; }

        public ProcessorSocket Socket { get; set; }

        public MbChipset Chipset { get; set; }

        public Interface Interface { get; set; }

        public Graphics Graphics { get; set; }

        [Column("Memory type")]
        public MemoryType MemoryType { get; set; }

        public Port Port { get; set; }

        [Column("Form factor")]
        public FormFactor FormFactor { get; set; }
    }
}
