namespace Bitak.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Runtime.CompilerServices;
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

        public IActionResult List([FromForm] Dictionary<string, string> brand)
        {
            foreach (var item in Enum.GetValues(typeof(Brand)))
            {
                this.ViewData[$"{item}"] = string.Empty;
            }

            if (brand.Count > 1)
            {
                foreach (var item in brand.Keys.SkipLast(1))
                {
                    this.ViewData[$"{item}"] = "checked";
                }
                var filteredMainboards = this.MainBoardService.GetAll<MainBoardViewModel>();

                var predicate =
                from mainboard in filteredMainboards
                where brand.Keys.SkipLast(1).Contains(mainboard.Brand.ToString())
                select mainboard;

                var filteredModel = new MainBoardListViewModel { Mainboards = predicate };


                return this.View(filteredModel);
            }

            var mainboards = this.MainBoardService.GetAll<MainBoardViewModel>().ToList();
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

        //[HttpPost]
        public IActionResult FilterByBrand([FromForm] Dictionary<string, string> brand)
        {
            var mainboards = this.MainBoardService.GetAll<MainBoardViewModel>();

            var predicate =
            from mainboard in mainboards
            where brand.Keys.SkipLast(1).Contains(mainboard.Brand.ToString())
            select mainboard;

            var model = new MainBoardListViewModel() { Mainboards = predicate };

            return this.RedirectToAction("List", new { predicate = "Kurrrrrr!!!" });
        }
    }
}
