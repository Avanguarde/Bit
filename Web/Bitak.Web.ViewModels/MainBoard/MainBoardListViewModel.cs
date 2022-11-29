namespace Bitak.Web.ViewModels.MainBoard
{
    using System.Collections.Generic;

    public class MainBoardListViewModel
    {
        public MainBoardListViewModel()
        {
            this.Mainboards = new List<MainBoardViewModel>();
        }

        public IEnumerable<MainBoardViewModel> Mainboards { get; set; }
    }
}
