using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EntrySlider
    {
        public int Id { get; set; }
        [Display(Name="Alt Başlık")]
        public string Subtitle { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Kısa Yazı")]

        public string Description { get; set; }
        [Display(Name = "Resim")]

        public string Image { get; set; }
    }
}
