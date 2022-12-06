namespace Bitak.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using Bitak.Common;
    using Bitak.Data;
    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Data.Models.PcComponents.Enums;
    using Bitak.Services.Data;
    using Bitak.Services.Mapping;
    using Bitak.Web.ViewModels.MainBoard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NuGet.Packaging.Signing;
    using NuGet.Protocol;
    using SendGrid.Helpers.Mail;

    public class MainBoardController : BaseController
    {
        public MainBoardController(IMainBoardService mainBoardService, IDeletableEntityRepository<MainBoard> repository)
        {
            this.MainBoardService = mainBoardService;
            this.Repository = repository;
        }

        public IMainBoardService MainBoardService { get; }

        public IDeletableEntityRepository<MainBoard> Repository { get; }

        [Route("MainBoard/{id:int}")]
        public IActionResult Index(int id)
        {
            var model = this.MainBoardService.GetAll<MainBoardViewModel>().FirstOrDefault(x => x.Id == id);
            return this.View(model);
        }

        public IActionResult List()
        {
            var mainboards = this.MainBoardService.GetAll<MainBoardViewModel>();

            var model = new MainBoardListViewModel { Mainboards = mainboards };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Add(MainBoardViewModel mainBoardModel)
        {
            var mainBoard = this.MainBoardService.MakeModel(mainBoardModel);
            await this.Repository.AddAsync(mainBoard);
            await this.Repository.SaveChangesAsync();
            return this.RedirectToAction($"Index", new { id = mainBoard.Id });
        }
        [HttpPost]
        public IActionResult FilterByBrand(Dictionary<string, string> dic)
        {
            foreach (var item in dic)
            {
                var splt = item.Key.Split(' ');
                var fltr = splt[1];
                var name = splt[0];

                switch (name)
                {

                    case "Brand":
                        var list = this.MainBoardService.GetAll<MainBoardViewModel>().Where(x => x.Brand.ToString() == fltr);
                        var model = new MainBoardListViewModel { Mainboards = list };
                        return RedirectToAction("List", model);
                    default:
                        return RedirectToAction("List");
                        break;
                }
            }

            return this.Ok();
        }
    }
}
