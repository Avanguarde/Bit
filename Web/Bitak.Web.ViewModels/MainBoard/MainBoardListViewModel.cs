namespace Bitak.Web.ViewModels.MainBoard
{
    using System;
    using System.Collections.Generic;

    public class MainBoardListViewModel
    {
        public MainBoardListViewModel()
        {
            this.Mainboards = new List<MainBoardViewModel>();
        }

        public IEnumerable<MainBoardViewModel> Mainboards { get; set; }

        /// <summary>
        /// Returns List<string> of all brand in database
        /// </summary>
        public List<string> GetBrands()
        {
            if (this.Mainboards == null)
            {
                throw new NullReferenceException();
            }

            var list = new List<string>();

            foreach (var item in this.Mainboards)
            {
                if (!list.Contains(item.Brand.ToString()))
                {
                    list.Add(item.Brand.ToString());
                }
            }

            return list;
        }

        public List<string> GetFormFactor()
        {
            if (this.Mainboards == null)
            {
                throw new NullReferenceException();
            }

            var list = new List<string>();

            foreach (var item in this.Mainboards)
            {
                if (!list.Contains(item.FormFactor.ToString()))
                {
                    list.Add(item.FormFactor.ToString());
                }
            }

            return list;
        }

        public List<string> GetChipset()
        {
            if (this.Mainboards == null)
            {
                throw new NullReferenceException();
            }

            var list = new List<string>();

            foreach (var item in this.Mainboards)
            {
                if (!list.Contains(item.Chipset.ToString()))
                {
                    list.Add(item.Chipset.ToString());
                }
            }

            return list;
        }
    }
}
