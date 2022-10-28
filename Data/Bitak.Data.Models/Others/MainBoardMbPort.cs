namespace Bitak.Data.Models.Others
{
    using Bitak.Data.Common.Models;
    using Bitak.Data.Models.PcComponents;

    public class MainBoardMbPort : BaseModel<int>
    {
        public int MainBoardId { get; set; }

        public MainBoard MainBoard { get; set; }

        public int MbPortId { get; set; }

        public MbPort MbPort { get; set; }
    }
}
