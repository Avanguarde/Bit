namespace Bitak.Data.Models.Others
{
    using Bitak.Data.Models.PcComponents;

    public class MainBoardMbInterface
    {
        public int MainBoardId { get; set; }

        public MainBoard MainBoard { get; set; }

        public int MbInterfaceId { get; set; }

        public MbInterface MbInterface { get; set; }
    }
}
