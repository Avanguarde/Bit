namespace Bitak.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

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
                Name = "GIGABYTE B650E AORUS MASTER AM5 LGA 1718 AMD B650 ATX Motherboard DDR5, Quad M.2, PCIe 5.0, USB 3.2 Gen2X2 Type-C, AMD WiFi 6E, Intel 2.5GbE LAN, Q-Flash Plus, EZ-Latch Plus",
                Brand = "Gygabyte",
                Price = 550.50m,
                Socket = ProcessorSocket.LGA1700,
                Chipset = MbChipset.INTELZ490,
                FormFactor = FormFactor.ATX,
                MemorySlots = 4,
                MemoryType = MemoryType.DDR5,
                Waranty = 36,
                Ports = "USB, USB3.0, Display port, Hdmi",
                Interfaces = "4xDDR4, PciE, M.2",
            });

            await dbContext.MainBoards.AddAsync(new MainBoard
            {
                Name = "ASUS TUF GAMING B650-PLUS WIFI Socket AM5 (LGA 1718) Ryzen 7000 ATX gaming motherboard(14 power stages, PCIe 5.0 M.2 support, DDR5 memory, 2.5 Gb Ethernet, WiFi 6, USB4® support and Aura Sync)",
                Brand = "Asus",
                Price = 350.50m,
                Socket = ProcessorSocket.AM4,
                Chipset = MbChipset.AMDA320,
                FormFactor = FormFactor.ATX,
                MemorySlots = 4,
                MemoryType = MemoryType.DDR4,
                Waranty = 24,
                Ports = "USB, USB3.0, Display port, Hdmi",
                Interfaces = "4xDDR4, PciE, M.2",
            });
        }
    }
}
