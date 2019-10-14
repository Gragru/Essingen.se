using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Essingen.Models
{
    public class PlaceCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}