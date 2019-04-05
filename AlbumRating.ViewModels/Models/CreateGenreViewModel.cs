namespace AlbumRating.ViewModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateGenreViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}