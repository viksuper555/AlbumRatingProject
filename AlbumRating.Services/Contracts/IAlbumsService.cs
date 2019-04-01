using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumRating.Services.Contracts
{
    public interface IAlbumsService
    {
        int CreateAlbum(int AlbumId, string title, string artist, int year, string genre);
    }
}
