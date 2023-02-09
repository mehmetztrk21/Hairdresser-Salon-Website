using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class GeneralModel
    {
        public List<Campaign> Kampanyalar { get; set; }
        public List<EntrySlider> EntrySliders { get; set; }
        public General General { get; set; }
        public List<Image> Resimler { get; set; }
        public List<PriceList> Fiyatlar { get; set; }
        public List<Services> Servisler { get; set; }
        public List<Team> Elemanlar { get; set; }
    }
}
