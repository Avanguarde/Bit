namespace Bitak.Web.Controllers
{
    using Bitak.Common;
    using Bitak.Data.Models;
    using Bitak.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class AdminPanelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public AdminPanelController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> CreateUser()
        {
            var user = await this.userManager.CreateAsync(
                new ApplicationUser()
            {
                Email = "koko_ko@admin.bg",
                CreatedOn = DateTime.UtcNow,
            },
                "123456");
            return this.Ok();
        }


        public async Task<IActionResult> AddUserToRole()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            return this.Ok();
        }

    }
}
