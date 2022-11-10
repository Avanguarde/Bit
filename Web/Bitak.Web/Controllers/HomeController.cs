namespace Bitak.Web.Controllers
{
    using System.Diagnostics;

    using Bitak.Services.Data;
    using Bitak.Web.ViewModels;
    using Bitak.Web.ViewModels.MainBoard;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IMainBoardService mainBoardService;

        public HomeController(IMainBoardService mainBoardService)
        {
            this.mainBoardService = mainBoardService;
        }

        public IActionResult Index()
        {
            var mainboards = this.mainBoardService.GetAll<MainBoardViewModel>();
            var model = new MainBoardListViewModel { Mainboards = mainboards };
            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
