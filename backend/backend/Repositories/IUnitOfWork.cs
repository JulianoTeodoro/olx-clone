namespace backend.Repositories
{
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository { get; }
        IAdsRepository AdsRepository { get; }
        IimageRepository ImageRepository { get; }
        Task Commit();
        void Dispose();

    }
}
