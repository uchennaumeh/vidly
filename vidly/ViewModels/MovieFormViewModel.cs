using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //removing next line to have a complete viewModel for the movieForm view
        //public Movie Movie { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //remove date added as this isnt need on the form as well
        //public DateTime DateAdded { get; set; }

        //remove genre as the view (our form) doesnt have genre, only genreID
        //public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)
                    return "EDIT MOVIE";

                return "NEW MOVIE";

            }
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
    }
}