using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WEB_MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        //  SelectList 这使用户能够从列表中选择一种流派
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
