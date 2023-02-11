using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;

namespace WebApiSeyyedi.Infrastructure.RepositoryClasses
{
    public class BookDetailRepository : Repository<BookDetail,int>, IBookDetailRepository
    {
        public BookDetailRepository(WEBAPIContext dbContext) : base(dbContext) { }
    }
}
