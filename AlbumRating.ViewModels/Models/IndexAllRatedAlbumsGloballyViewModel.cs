using AlbumRating.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AlbumRating.ViewModels.Models
{
    public class IndexAllRatedAlbumsGloballyViewModel
    {
        public List<Album> Albums { get; set; }

        public Dictionary<Album, List<int>> AlbumWithRating = new Dictionary<Album, List<int>>();
    }
}
