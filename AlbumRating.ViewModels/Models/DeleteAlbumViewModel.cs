using AlbumRating.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumRating.ViewModels.Models
{
    public class DeleteAlbumViewModel
    {
        public string Title { get; set; }

        public int AlbumId { get; set; }

        public List<Album> Albums { get; set; }

    }
}
