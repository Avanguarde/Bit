namespace Bitak.Web.ViewModels.SideBar
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Bitak.Data.Models;
    using Bitak.Data.Models.PcComponents;
    using Bitak.Data.Models.PcComponents.Enums;
    using Bitak.Services.Mapping;
    using Bitak.Web.ViewModels.Settings;

    //TODO

    public class SideBarViewModel : IMapFrom<MainBoard>, IHaveCustomMappings
    {
        public List<Dictionary<Brand, bool>> Brands { get; set; }

        public List<Dictionary<FormFactor, bool>> FormFactors { get; set; }

        public List<Dictionary<MbChipset, bool>> Chipsets { get; set; }

        public Dictionary<double, double> MinAndMaxPrice { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            var brands = Enum.GetValues<Brand>();

            configuration.CreateMap<MainBoard, SideBarViewModel>().ForMember(
                m => m.Brands,
                opt => opt.MapFrom(x => x.Brand));


                //configuration.CreateMap<Setting, SettingViewModel>().ForMember(
                //m => m.NameAndValue,
                //opt => opt.MapFrom(x => x.Name + " = " + x.Value));
        }
    }
}
