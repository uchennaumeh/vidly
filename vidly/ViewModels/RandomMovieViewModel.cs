using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Customer> Customers { get; set; }
        public Movie Movie { get; set; }
    }
}