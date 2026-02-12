using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MovieDiaryApp
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("vote_average")]
        public double Rating { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonIgnore]
        public string PosterUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PosterPath))
                    return null;

                return "https://image.tmdb.org/t/p/w200" + PosterPath;
            }
        }
    }
}