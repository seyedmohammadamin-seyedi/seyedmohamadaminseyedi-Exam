using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;

namespace WebApiSeyyedi.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();

        WEBAPIContext DbContext { get; }

        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IBookDetailRepository BookDetailRepository { get; }
        IBookRepository BookRepository { get; }
        IProvinceRepository ProvinceRepository { get; }
        ICityRepository CityRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ILibraryRepository LibraryRepository { get; }
    }
}
