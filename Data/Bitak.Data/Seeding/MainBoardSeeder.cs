namespace Bitak.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Threading.Tasks;

    using Bitak.Data.Models;
    using Bitak.Data.Models.Others;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Data.Models.PcComponents.Enums;

    internal class MainBoardSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.MainBoards.Any())
            {
                return;
            }

            await dbContext.MainBoards.AddAsync(new MainBoard
            {
                Name = "Gygabyte",
                Brand = "Asus",
                Price = 350.50m,
                Socket = ProcessorSocket.AM4,
                Chipset = MbChipset.AMDA320,
                FormFactor = FormFactor.ATX,
                MemorySlots = 4,
                MemoryType = MemoryType.DDR4,
                Waranty = 24,
                Ports = new List<MbPort>
                {
                    new MbPort
                    {
                        Name = "Lan",
                        Description = "Lan Port Overview",
                    },
                    new MbPort
                    {
                        Name = "Usb3",
                        Description = "USB3 Overview",
                    },
                },
                Interfaces = new List<MbInterface>
                {
                    new MbInterface
                    {
                        Name = "M2",
                        Description = "BlaBlaBla",
                    },
                    new MbInterface
                    {
                        Name = "PCIE",
                        Description = "BloBloBlo",
                    },
                },
            });
        }
    }
}
