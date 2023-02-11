using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;


namespace WebApiSeyyedi.Infrastructure.RepositoryClasses
{
    public class LibraryRepository : Repository<Library, int>, ILibraryRepository
    {
        public LibraryRepository(WEBAPIContext dbContext) : base(dbContext) { }
    }
}
