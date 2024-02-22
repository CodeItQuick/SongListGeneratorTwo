using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Adapter;

[Table("songs")]
public class SongsDbo
{
    [Key]
    public string track_id { get; set; }
    public string title { get; set; }
    public string song_id { get; set; }
    public string release { get; set; }
    public string artist_id { get; set; }
    public string artist_mbid { get; set; }
    public string artist_name { get; set; }
    public double duration { get; set; }
    public double artist_familiarity { get; set; }
    public double artist_hotttnesss { get; set; }
    public int year { get; set; }
    public int track_7digitalid { get; set; }
    public int shs_perf { get; set; }
    public int shs_work { get; set; }
    public List<ArtistMbTag> ArtistMbTags { get; set; }
}