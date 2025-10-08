using emxinhsayhi.Models;
using System.Collections.Generic;
using System.Data.Entity;


namespace MvcMusicStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<MusicStoreEntities>
    {
        protected override void Seed(MusicStoreEntities context)
        {
            var genres = new List<Genre>
{
new Genre { Name = "Rock" },
new Genre { Name = "Jazz" }
};
            genres.ForEach(g => context.Genres.Add(g));
            context.SaveChanges();


            var artists = new List<Artist>
{
new Artist { Name = "Artist A" },
new Artist { Name = "Artist B" }
};
            artists.ForEach(a => context.Artists.Add(a));
            context.SaveChanges();


            context.Albums.Add(new Album
            {
                Title = "Album 1",
                Genre = genres[0],
                Artist = artists[0],
                Price = 9.99m,
                AlbumArtUrl = "/Content/Images/placeholder.png"
            });


            context.SaveChanges();
        }
    }
}