namespace Bitak.Services.Data
{
    using System;

    public class EnumService : IEnumService
    {
        public Array GetAll<T>()
        {
            var output = Enum.GetValues(typeof(T));

            return output;
        }
    }
}
