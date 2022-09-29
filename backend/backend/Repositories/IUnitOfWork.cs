namespace backend.Repositories
{
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository { get; }

        Task Commit();
        void Dispose();

    }
}
