using System.Collections.Generic;

namespace Bitak.Services.Data
{
    public interface IRepository
    {
        IEnumerable<object> All();
    }
}