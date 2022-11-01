namespace Bitak.Web.Controllers
{
    using System.Threading.Tasks;

    using Bitak.Common;
    using Bitak.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> CreateUser()
        {
            await this.roleManager.CreateAsync(new ApplicationRole { Name = GlobalConstants.AdministratorRoleName });

            var user = await this.userManager.GetUserAsync(this.User);

            await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);

            return this.Ok();
        }
    }
}
