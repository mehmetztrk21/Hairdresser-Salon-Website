using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Services
    {
        public int Id { get; set; }
        [Display(Name="Başlık")]
        public string Title { get; set; }
        [Display(Name = "Hakkında")]

        public string Description  { get; set; }
        [Display(Name = "İkon")]

        public string Icon { get; set; }
        [Display(Name = "Ana Sayfa")]

        public bool HomePage { get; set; }

    }
}
