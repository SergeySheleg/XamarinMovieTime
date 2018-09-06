using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Models
{
    class Film
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double IMDBRating { get; set; }
        public double UserRating { get; set; }
        public Image Image { get; set; }
    }
}
