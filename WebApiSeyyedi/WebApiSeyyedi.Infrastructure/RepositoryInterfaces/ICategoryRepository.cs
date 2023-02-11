using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;

namespace WebApiSeyyedi.Infrastructure.RepositoryInterfaces
{
    public interface ICategoryRepository : IRepository<Category,int>
    {
    }
}
