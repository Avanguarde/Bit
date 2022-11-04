namespace Bitak.Services.Data
{
    using Bitak.Data.Models.PcComponents;
    using Bitak.Web.ViewModels.MainBoard;
    using System.Collections.Generic;

    public interface IMainBoardService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        MainBoard MakeModel(MainBoardViewModel viewModel);
    }
}
