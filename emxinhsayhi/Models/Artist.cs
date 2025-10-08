using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emxinhsayhi.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required, StringLength(160)]
        public string Name { get; set; }
    }
}