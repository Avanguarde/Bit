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
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using NuGet.Protocol;
    using System.Drawing.Drawing2D;

    public class MainBoardController : BaseController
    {
        public MainBoardController(IMainBoardService mainBoardService, IDeletableEntityRepository<MainBoard> repository)
        {
            this.MainBoardService = mainBoardService;
            this.Repository = repository;
        }

        public IMainBoardService MainBoardService { get; }

        public IDeletableEntityRepository<MainBoard> Repository { get; }

        public IActionResult Index(string brand)
        {
            var mainboards = this.MainBoardService.GetAll<MainBoardViewModel>();
            var model = new MainBoardListViewModel { Mainboards = mainboards };

            //if (brand != null)
            //{
            //    var models = this.MainBoardService
            //    .GetAll<MainBoardViewModel>()
            //    .Where(b => b.Brand == brand)
            //    .ToList();

            //    model = new MainBoardListViewModel { Mainboards = models };
            //}
            
            return this.View(model);
        }

        
        //public IActionResult Index(string brand)
        //{
        //    var models = this.MainBoardService
        //    .GetAll<MainBoardViewModel>()
        //    .Where(b => b.Brand == brand)
        //    .ToList();

        //    var model = new MainBoardListViewModel { Mainboards = models };

        //    return this.View(model);
        //}

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

        //public IActionResult FilterByBrand(string brand)
        //{
        //    var models = this.MainBoardService
        //    .GetAll<MainBoardViewModel>()
        //    .Where(b => b.Brand == brand)
        //    .ToList();

        //    var model = new MainBoardListViewModel { Mainboards = models };

        //    this.TempData["MainBoardList"] = model;

        //    return this.RedirectToAction("Index", "MainBoard");
        //}
    }
}
