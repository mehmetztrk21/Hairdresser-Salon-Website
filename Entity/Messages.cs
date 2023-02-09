using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Messages
    {
        public int Id { get; set; }
        [Display(Name="Ad")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telefon")]

        public string Phone { get; set; }
        [Display(Name = "Mesaj")]

        public string Context { get; set; }
        [Display(Name = "Tarih")]

        public DateTime Date { get; set; }
    }
}
