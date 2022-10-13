namespace backend.Repositories
{
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository { get; }
        IAdsRepository AdsRepository { get; }
        Task Commit();
        void Dispose();

    }
}
