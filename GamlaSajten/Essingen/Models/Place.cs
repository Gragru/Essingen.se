using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Essingen.Models
{
    public class Place
    {
        public int Id { get; set; }
        [Display(Name = "Område")]
        public Variables.Enums.Area Area { get; set; }
        [Display(Name = "Namn")]
        public string SignName { get; set; }
        public string CorporateName { get; set; }
        [Display(Name = "Latitud")]
        [DisplayFormat(DataFormatString = "{0:F6}", ApplyFormatInEditMode = true)]
        public decimal Latitude { get; set; }
        [Display(Name = "Longitud")]
        [DisplayFormat(DataFormatString = "{0:F6}", ApplyFormatInEditMode = true)]
        public decimal Longitude { get; set; }
        [Display(Name = "1")]
        public int PlaceCategoryId { get; set; }
        [Display(Name = "2")]
        virtual public PlaceCategory PlaceCategory { get; set; }
        [Display(Name = "Adress")]
        public string Streetaddress { get; set; }
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Epost")]
        public string Email { get; set; }
        [Display(Name = "Webbsida")]
        public string Url { get; set; }
        [Display(Name = "Huvudbild")]
        public string MainImage { get; set; }
        [Display(Name = "Publicerad")]
        public bool Published { get; set; }

    }
}