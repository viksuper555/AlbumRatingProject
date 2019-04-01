using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumRating.Services.Contracts
{
    public interface IAlbumsService
    {
        int CreateAlbum(string title, string artist, int year, string genre);

        int DeleteAlbum(string title);

    }
}
