using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumRating.Services.Contracts
{
    public interface IRateAlbumService
    {
        int RateAlbum(string title, int rating, int userId);
    }
}
