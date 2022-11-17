namespace Bitak.Web.Controllers
{
    using System.Linq;

    using Bitak.Data.Models.PcComponents.Enums;
    using Bitak.Services.Data;
    using Bitak.Web.ViewModels.MainBoard;
    using Bitak.Web.ViewModels.SideBar;
    using Microsoft.AspNetCore.Mvc;

    public class SidebarController : BaseController
    {
        private readonly IMainBoardService mainBoardService;
        private readonly IEnumService enumService;

        public SidebarController(IMainBoardService mainBoardService, IEnumService enumService)
        {
            this.mainBoardService = mainBoardService;
            this.enumService = enumService;
        }

        public IActionResult GetAll()
        {
            var data = this.mainBoardService.GetAll<MainBoardViewModel>().FirstOrDefault();
            var model = new SideBarViewModel
            {
                Brands = this.enumService.GetAll<Brand>(),
                Socket = this.enumService.GetAll<ProcessorSocket>(),
            };
            return this.PartialView("_SidebarFilterPartial", model);
        }
    }
}
