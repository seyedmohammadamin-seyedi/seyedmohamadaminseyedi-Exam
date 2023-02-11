using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;

namespace WebApiSeyyedi.Infrastructure.RepositoryClasses
{
    public class UserRepository : Repository<User,int>, IUserRepository
    {
        public UserRepository(WEBAPIContext dbContext) : base(dbContext) { }
    }
}
