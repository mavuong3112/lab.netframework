using emxinhsayhi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcMusicStore.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        [DisplayName("Artist")]
        public int ArtistId { get; set; }


        [Required, StringLength(160)]
        public string Title { get; set; }
        [Range(typeof(decimal), "0.01", "100.00")]
        public decimal Price { get; set; }
        [DisplayName("Album Art Url")]
        public string AlbumArtUrl { get; set; }


        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}