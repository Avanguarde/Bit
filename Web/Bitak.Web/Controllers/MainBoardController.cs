namespace Bitak.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Bitak.Common;
    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Data.Repositories;
    using Bitak.Services.Data;
    using Bitak.Web.ViewModels.MainBoard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class MainBoardController : BaseController
    {
        public MainBoardController(IMainBoardService mainBoardService, IDeletableEntityRepository<MainBoard> repository)
        {
            this.MainBoardService = mainBoardService;
            this.Repository = repository;
        }

        public IMainBoardService MainBoardService { get; }

        public IDeletableEntityRepository<MainBoard> Repository { get; }

        public IActionResult Index()
        {
            MainBoardListViewModel mainBoards = new MainBoardListViewModel { Mainboards = this.MainBoardService.GetAll<MainBoardViewModel>().ToList() };
            return this.View(mainBoards);
        }

        //[HttpPost]
        //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Add(MainBoard mainBoard)
        {
            //await this.Repository.AddAsync(mainBoard);
            //await this.Repository.SaveChangesAsync();
            return this.View();
        }


    }
}
