using System.Text.Json;

namespace MyCoach.API.Storage
{
    public sealed class FileJsonStore : IJsonStore
    {
        private readonly string _root;
        private static readonly JsonSerializerOptions _opts = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = false
        };

        public FileJsonStore(JsonStorageOptions options)
        {
            _root = options.RootPath;
            Directory.CreateDirectory(_root);
        }

        public async Task<T?> ReadAsync<T>(string fileName, CancellationToken ct = default)
        {
            var path = Path.Combine(_root, fileName);
            if (!File.Exists(path)) return default;
            await using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return await JsonSerializer.DeserializeAsync<T>(fs, _opts, ct);
        }

        public async Task WriteAsync<T>(string fileName, T data, CancellationToken ct = default)
        {
            var path = Path.Combine(_root, fileName);
            var tmp = path + ".tmp";

            // Écritures atomiques : écrire dans un tmp puis remplacer
            await using (var fs = new FileStream(tmp, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await JsonSerializer.SerializeAsync(fs, data, _opts, ct);
                await fs.FlushAsync(ct);
            }

            // Remplace le fichier final (cross-platform)
            if (File.Exists(path))
                File.Replace(tmp, path, null);
            else
                File.Move(tmp, path);
        }
    }
}
