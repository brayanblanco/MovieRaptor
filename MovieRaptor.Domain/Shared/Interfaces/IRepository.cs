namespace MovieRaptor.Domain.Shared.Interfaces
{
    public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T> where T : class
    {
    }
}
