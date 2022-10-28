namespace Bitak.Services.Data
{
    using System.Collections.Generic;

    public interface IProductService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
