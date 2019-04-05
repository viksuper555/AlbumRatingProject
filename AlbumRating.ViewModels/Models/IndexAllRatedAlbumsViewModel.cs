using AlbumRating.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AlbumRating.ViewModels.Models
{
    public class IndexAllRatedAlbumsViewModel
    {
        public List<UserRatedAlbum> RatedAlbums { get; set; }
            
        public List<Album> Albums { get; set; }
    }
}
