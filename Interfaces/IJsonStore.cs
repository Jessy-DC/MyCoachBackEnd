namespace MyCoach.API.Storage
{
    public interface IJsonStore
    {
        Task<T?> ReadAsync<T>(string fileName, CancellationToken ct = default);
        Task WriteAsync<T>(string fileName, T data, CancellationToken ct = default);
    }
}
