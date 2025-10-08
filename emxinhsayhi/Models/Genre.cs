using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emxinhsayhi.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required, StringLength(120)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}