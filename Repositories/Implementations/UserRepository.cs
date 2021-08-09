using DAL;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public DatabaseContext context
        {
            get
            {
                return _dbContext as DatabaseContext;
            }
        }
        public UserRepository(DbContext _db) : base(_db)
        {

        }
        public PagingModel<UserModel> GetUsers(int page, int pageSize)
        {
            var data = (from usr in context.Users
                        
                        select new UserModel
                        {
                            Id = usr.Id,
                            Name = usr.Name,
                            Photo = usr.Photo,
                            Designation = usr.Designation,
                            CountryName = usr.Country,
                            Gender = usr.Gender,
                            Email = usr.Email,
                            MobileNo = usr.MobileNo
                        });

            int count = data.Count();
            var dataList = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PagingModel<UserModel> model = new PagingModel<UserModel>();
            if (dataList.Count > 0)
            {
                model.Data = new StaticPagedList<UserModel>(dataList, page, pageSize, count);
                model.Page = page;
                model.PageSize = pageSize;
                model.TotalPages = count;
            }
            return model;
        }
    }
}
