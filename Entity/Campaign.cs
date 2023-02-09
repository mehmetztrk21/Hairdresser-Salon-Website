using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Campaign
    {
        public int Id { get; set; }
        [Display(Name="Kampanya")]
        public string Description { get; set; }
        [Display(Name = "Son Gün")]

        public DateTime Date { get; set; }
    }
}
