namespace Bitak.Web.ViewModels.SideBar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Bitak.Data.Models.PcComponents.Enums;

    public class SideBarViewModel
    {
        public Array Brands { get; set; }

        public Array Socket { get; set; }

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
