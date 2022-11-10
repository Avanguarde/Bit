namespace Bitak.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Bitak.Services.Data;
    using Bitak.Web.ViewModels.MainBoard;
    using Microsoft.AspNetCore.Mvc;

    public class SidebarController : BaseController
    {
        private readonly IMainBoardService mainBoardService;

        public SidebarController(IMainBoardService mainBoardService)
        {
            this.mainBoardService = mainBoardService;
        }

        public IActionResult GetAll()
        {
            var mainboards = this.mainBoardService.GetAll<MainBoardViewModel>();
            var model = new MainBoardListViewModel { Mainboards = mainboards };
            return this.PartialView("_SidebarFilterPartial", model);
        }
    }
}
