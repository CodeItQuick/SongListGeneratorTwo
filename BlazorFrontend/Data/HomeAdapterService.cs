using System.Data;
using System.Data.Common;
using Application.Adapter;
using Microsoft.EntityFrameworkCore;

namespace BlazorFrontend.Data;

public class HomeAdapterService
{
    private SongsDbContext SongsDbContext { get; }

    public HomeAdapterService()
    {
        SongsDbContext = new SongsDbContext();
        SongsDbContext.Database.EnsureCreated();
    }

    public Task<HomeView> OnGet()
    {
        return Task.FromResult(new HomeView());
    }

    public Task<HomeView> Create(string genre)
    {
        var artists = this.SongsDbContext
            .Songs
            .Include(x => x.ArtistMbTags)
            .Where(x => x.ArtistMbTags.Any(x => x.mbtag.Contains(genre)))
            .Select(x => new Songs() { Artist = x.artist_name, ArtistId = x.artist_id })
            .Distinct()
            .ToList();
        var artistList = new HomeView()
        {
            Artists = artists,
            Genre = genre
        };
        return Task.FromResult(artistList);
    }

    public Task<HomeView> CreateSongList(string artistId, string genre)
    {
        string selectStatement = $@"SELECT 
            artist_name,
            title
            FROM songs 
            WHERE artist_id IN (
            SELECT DISTINCT similarity.similar 
            FROM artists 
            JOIN similarity ON artists.artist_id = similarity.target 
            JOIN songs ON songs.artist_id = similarity.similar 
            WHERE artists.artist_id = '{artistId}' 
            GROUP BY artist_name 
            ORDER BY AVG(artist_hotttnesss) DESC 
            LIMIT 30) 
            GROUP BY artist_name
            LIMIT 50;";
        var songsDbos = RawSqlQuery(selectStatement, x => 
            new SongsDbo() { artist_name = (string) x[0], title = (string) x[1] });
        var artists = this.SongsDbContext
            .Songs
            .Include(x => x.ArtistMbTags)
            .Where(x => x.ArtistMbTags.Any(x => x.mbtag.Contains(genre)))
            .Select(x => new Songs() { Artist = x.artist_name, ArtistId = x.artist_id })
            .Distinct()
            .ToList();

        return Task.FromResult(new HomeView()
        {
            Songs = songsDbos,
            Artists = artists,
            Genre = genre
        });
    }
    
    public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
    {
        using (var context = new SongsDbContext())
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
        }
    }
}