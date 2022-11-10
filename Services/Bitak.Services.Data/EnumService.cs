using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitak.Data.Models.PcComponents.Enums;

namespace Bitak.Services.Data
{
    public class EnumService : IEnumService
    {
              public Array GetAll<T>()
        {
            var output = Enum.GetValues(typeof(T));

            return output;
        }
    }
}
