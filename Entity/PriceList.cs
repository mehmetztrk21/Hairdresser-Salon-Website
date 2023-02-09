using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PriceList
    {
        public int Id { get; set; }
        [Display(Name="Hizmet")]
        public string Name { get; set; }
        [Display(Name = "Fiyat")]

        public double Price { get; set; }
    }
}
