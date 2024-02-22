using Application.Adapter;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorFrontend.Data;

public class HomeView
{
    public List<SelectListItem> GenreList { get; set; } =
    [
        new SelectListItem { Text = "united states", Value = "united states" },
        new SelectListItem { Text = "américain", Value = "américain" },
        new SelectListItem { Text = "britannique", Value = "britannique" },
        new SelectListItem { Text = "alternative metal", Value = "alternative metal" },
        new SelectListItem { Text = "blues rock", Value = "blues rock" },
        new SelectListItem { Text = "united kingdom", Value = "united kingdom" },
        new SelectListItem { Text = "hard rock", Value = "hard rock" },
        new SelectListItem { Text = "rap", Value = "rap" },
        new SelectListItem { Text = "alternative rock", Value = "alternative rock" },
        new SelectListItem { Text = "rnb", Value = "rnb" },
        new SelectListItem { Text = "heavy metal", Value = "heavy metal" },
        new SelectListItem { Text = "pop and chart", Value = "pop and chart" },
        new SelectListItem { Text = "experimental", Value = "experimental" },
        new SelectListItem { Text = "hiphop", Value = "hiphop" },
        new SelectListItem { Text = "indie rock", Value = "indie rock" },
        new SelectListItem { Text = "soul", Value = "soul" },
        new SelectListItem { Text = "punk rock", Value = "punk rock" },
        new SelectListItem { Text = "90s", Value = "90s" },
        new SelectListItem { Text = "metal", Value = "metal" },
        new SelectListItem { Text = "hip-hop", Value = "hip-hop" },
        new SelectListItem { Text = "singer", Value = "singer" },
        new SelectListItem { Text = "rock", Value = "rock" },
        new SelectListItem { Text = "hip hop rnb and dance hall", Value = "hip hop rnb and dance hall" },
        new SelectListItem { Text = "death metal", Value = "death metal" },
        new SelectListItem { Text = "pop rock", Value = "pop rock" },
        new SelectListItem { Text = "pop", Value = "pop" },
        new SelectListItem { Text = "usa", Value = "usa" },
        new SelectListItem { Text = "dance", Value = "dance" },
        new SelectListItem { Text = "ambient", Value = "ambient" },
        new SelectListItem { Text = "indie pop", Value = "indie pop" },
        new SelectListItem { Text = "synthpop", Value = "synthpop" },
        new SelectListItem { Text = "electronica", Value = "electronica" },
        new SelectListItem { Text = "80s", Value = "80s" },
        new SelectListItem { Text = "reggae", Value = "reggae" },
        new SelectListItem { Text = "new wave", Value = "new wave" },
        new SelectListItem { Text = "downtempo", Value = "downtempo" },
        new SelectListItem { Text = "producer", Value = "producer" },
        new SelectListItem { Text = "house", Value = "house" },
        new SelectListItem { Text = "thrash metal", Value = "thrash metal" },
        new SelectListItem { Text = "rock and indie", Value = "rock and indie" }
    ];

    public List<Songs>? Artists { get; set; } = new();
    public List<SongsDbo>? Songs { get; set; } = new();
    public string Genre { get; set; }
}