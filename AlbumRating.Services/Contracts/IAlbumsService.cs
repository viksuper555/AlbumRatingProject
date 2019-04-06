namespace AlbumRating.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlbumRating.Data.Models;

    /// <summary>
    /// IAlbumsService is an interface class for the AlbumsService.
    /// The interface contains methods to manipulate and get data from the Albums table in the database.
    /// <list type="bullet">
    /// <item>
    /// <term>CreateAlbum</term>
    /// <description>The CreateAlbum method adds a new album to the database with the given parameters.</description>
    /// </item>
    /// <item>
    /// <term>DeleteAlbum</term>
    /// <description>The DeleteAlbum method deletes the album with the given id from the database.</description>
    /// </item>
    /// <item>
    /// <term>GetAllRatings</term>
    /// <description>The GetAllRatings method returns all the entries from the UserRatedAlbum table.</description>
    /// </item>
    /// <item>
    /// <term>GetAll</term>
    /// <description>The GetAll method returns all Albums from the database.</description>
    /// </item>
    /// </list>
    /// </summary>

    public interface IAlbumsService
    {
        int CreateAlbum(string title, string artist, int year, int genreId);

        int DeleteAlbum(int albumId);

        List<UserRatedAlbum> GetAllRatings();

        List<Album> GetAll();
    }
}