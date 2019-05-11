using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_web_api.Models
{
    public enum MovieGenre
    {
        Action,
        Comedy,
        Horror,
        Thriller  
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set;}
        public string Description { get; set;}
        public string Genre { get; set;}
        [EnumDataType(typeof(MovieGenre))]
        public int Duration { get; set;}
        public int YearOfRelease { get; set;}
        public string Director { get; set;}
        public DateTime DateAdded { get; set;}
        public int Rating { get; set;}
        [Range (1,10)]
        public bool Watched { get; set;}
       // public List<Comment> Comments { get; set; }
    }
}
