using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class General
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Slogan")]

        public string Slogan { get; set; }
        [Display(Name = "Hakkında")]

        public string Description { get; set; }
        [Display(Name = "Salon Resmi")]

        public string Saloon_img { get; set; }
        [Display(Name = "Salon Hakkında")]

        public string Saloon_Context { get; set; }
        [Display(Name = "Hakkında Sayfası Yazısı")]

        public string About_Context { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Display(Name = "E-mail")]

        public string Mail { get; set; }
        [Display(Name = "Telefon")]

        public string Phone { get; set; }
        [Display(Name = "Harita Linki")]

        public string Map { get; set; }
        [Display(Name = "İnstagram Linki")]

        public string Instagram { get; set; }
        [Display(Name = "Youtube Linki")]

        public string Youtube { get; set; }
        [Display(Name = "Whatsapp Linki")]


        public string Whatsapp { get; set; }

        [Display(Name = "Profil Resmi")]
        public string avatar { get; set; }
        [Display(Name = "Profil Resmi Altındaki Yazı")]

        public string avatar_context { get; set; }

        [Display(Name="Hizmetler Sayfası Paragrafı")]
        public string ServiceParagraf { get; set; }
        [Display(Name="İletişim Sayfası Paragrafı")]
        public string ContactParagraf { get; set; }

    }
}
