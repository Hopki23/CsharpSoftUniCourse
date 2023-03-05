namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var album = context.Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                                 .Select(s => new
                                 {
                                     s.Name,
                                     Price = s.Price.ToString("f2"),
                                     WirterName = s.Writer.Name
                                 })
                                 .OrderByDescending(s => s.Name)
                                 .ThenBy(s => s.WirterName)
                                 .ToArray(),
                    AlbumPrice = a.Price.ToString("F2")
                })
                .ToArray();

            foreach (var a in album)
            {
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine("-Songs:");

                int songsCount = 1;
                foreach (var s in a.AlbumSongs)
                {
                    sb.AppendLine($"---#{songsCount}");
                    sb.AppendLine($"---SongName: {s.Name}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.WirterName}");

                    songsCount++;
                }

                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    PerfomerNames = s.SongPerformers
                                    .Select(sp => new
                                    {
                                        PerformeName = sp.Performer.FirstName + ' ' + sp.Performer.LastName
                                    })
                                    .OrderBy(s => s.PerformeName)
                                    .ToArray(),
                    WriterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();

            int songCounter = 1;

            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{songCounter}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}");

                foreach (var p in s.PerfomerNames)
                {
                    sb.AppendLine($"---Performer: {p.PerformeName}");
                }

                sb.AppendLine($"---AlbumProducer: {s.ProducerName}")
                   .AppendLine($"---Duration: {s.Duration}");

                songCounter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
