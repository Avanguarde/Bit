namespace Bitak.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Bitak.Common;
    using Bitak.Data;
    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Services.Data;
    using Bitak.Web.ViewModels.MainBoard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Bitak.Services.Mapping;
    using System;

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

        public IActionResult Add() { return this.View(); }

        [HttpPost]
        //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Add(MainBoardViewModel mainBoardModel)
        {
            var mainBoard = this.MainBoardService.MakeModel(mainBoardModel);
            await this.Repository.AddAsync(mainBoard);
            await this.Repository.SaveChangesAsync();
            return this.RedirectToAction("Index");
        }


    }
}
