using DAL;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public PagingModel<UserModel> GetUsers(int page, int pageSize);
    }
}
