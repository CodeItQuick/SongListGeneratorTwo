using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Application.Adapter;

[Table("artist_mbtag")]
[PrimaryKey(nameof(artist_id), nameof(mbtag))]
public class ArtistMbTag
{
    [ForeignKey(nameof(Adapter.SongsDbo.artist_id))]
    public string artist_id { get; set; }
    public string mbtag { get; set; }
    public SongsDbo? SongsDbo { get; set; }
}