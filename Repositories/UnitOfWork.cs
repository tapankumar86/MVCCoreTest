using DAL;
using Repositories.Implementations;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext _db;
        public UnitOfWork(DatabaseContext db)
        {
            _db = db;
        }

        private IUserRepository _UserRepo;
        public IUserRepository UserRepo
        {
            get
            {
                if (_UserRepo == null)
                    _UserRepo = new UserRepository(_db);
                return _UserRepo;
            }
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
