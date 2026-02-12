using MovieDiaryApp;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieDiaryApp
{
    public class TmdbMovieResponse
    {
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; } = new List<Movie>();
    }
}
