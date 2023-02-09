using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Image
    {
        public int Id { get; set; }
        [Display(Name="Resim")]
        public string img { get; set; }
      
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
