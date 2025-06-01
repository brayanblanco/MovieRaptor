namespace MovieRaptor.Domain.Shared.Interfaces
{
    public interface IWriteRepository<T> where T : class
    {
        Task<Guid> CreateAsync(T entity, CancellationToken cancelationToken);
    }
}
