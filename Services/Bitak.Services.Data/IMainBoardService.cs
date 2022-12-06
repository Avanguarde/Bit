namespace Bitak.Services.Data
{
    using System.Collections.Generic;

    using Bitak.Data.Models.PcComponents;
    using Bitak.Web.ViewModels.MainBoard;

    public interface IMainBoardService
    {
        int GetCount();

        int GetCount(string val);

        IEnumerable<T> GetAll<T>();

        MainBoard MakeModel(MainBoardViewModel viewModel);
    }
}
