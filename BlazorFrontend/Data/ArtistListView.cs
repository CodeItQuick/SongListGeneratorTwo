namespace BlazorFrontend.Data;

public class ArtistListView
{
    public List<Songs> songs { get; set; }
}

public class Songs  
{
    public string Artist { get; set; }
    public string ArtistId { get; set; }
}