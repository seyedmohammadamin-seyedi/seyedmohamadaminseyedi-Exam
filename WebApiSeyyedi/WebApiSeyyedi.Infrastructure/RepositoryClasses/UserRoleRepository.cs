using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;

namespace WebApiSeyyedi.Infrastructure.RepositoryClasses
{
    public class UserRoleRepository : Repository<UserRole,int> , IUserRoleRepository
    {
        public UserRoleRepository(WEBAPIContext dbContext) : base(dbContext) { }
    }
}
