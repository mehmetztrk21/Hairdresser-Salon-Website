using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Team
    {
        public int Id { get; set; }
        [Display(Name="Ad")]
        public string name { get; set; }
        [Display(Name = "Hakkında")]

        public string description { get; set; }
        [Display(Name = "Resim")]

        public string image { get; set; }
        [Display(Name = "İnstagram")]

        public string instagram { get; set; }
        [Display(Name = "Email")]

        public string mail { get; set; }
        [Display(Name = "Telefon")]

        public string phone { get; set; }
    }
}
