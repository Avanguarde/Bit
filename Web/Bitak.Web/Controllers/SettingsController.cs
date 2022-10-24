namespace Bitak.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using Bitak.Data.Common.Repositories;
    using Bitak.Data.Models;
    using Bitak.Services.Data;
    using Bitak.Web.ViewModels.Settings;

    using Microsoft.AspNetCore.Mvc;

    public class SettingsController : BaseController
    {
        private readonly ISettingsService settingsService;

        private readonly IDeletableEntityRepository<Setting> repository;

        public SettingsController(ISettingsService settingsService, IDeletableEntityRepository<Setting> repository)
        {
            this.settingsService = settingsService;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var settings = this.settingsService.GetAll<SettingViewModel>();
            var model = new SettingsListViewModel { Settings = settings };
            return this.View(model);
        }

        public async Task<IActionResult> InsertSetting()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };

            await this.repository.AddAsync(setting);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }

        // TODO: Write tests
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> RemoveSetting(int id)
        {
            var setting = this.repository.All().Where(set => set.Id == id).FirstOrDefault();

            if (setting != null)
            {
                this.repository.Delete(setting);
            }

            await this.repository.SaveChangesAsync();

            return this.Redirect(nameof(this.Index));
        }

        // TODO: Write tests
        public async Task<IActionResult> BackupSetting(int id)
        {
            var setting = this.repository.AllWithDeleted().Where(set => set.Id == id).FirstOrDefault();

            if (setting != null)
            {
                this.repository.Undelete(setting);
            }

            await this.repository.SaveChangesAsync();
            return this.Redirect(nameof(this.Index));

        }
    }
}
