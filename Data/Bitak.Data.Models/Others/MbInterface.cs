namespace Bitak.Data.Models.Others
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bitak.Data.Common.Models;

    public class MbInterface : BaseModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        public List<MainBoardMbInterface> MainBoardMbInterface { get; set; }
    }
}
