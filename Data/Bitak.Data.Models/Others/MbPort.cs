namespace Bitak.Data.Models.Others
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bitak.Data.Common.Models;

    public class MbPort : BaseModel<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 10)]
        public string Description { get; set; }

        public List<MainBoardMbPort> MainBoardMbPort { get; set; }
    }
}
