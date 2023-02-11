using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Infrastructure.RepositoryClasses;
using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;

namespace WebApiSeyyedi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private ILibraryRepository _libraryRepository;
        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository;
        private IBookRepository _bookRepository;
        private IBookDetailRepository _bookDetailRepository;
        private IProvinceRepository _provinceRepository;
        private ICityRepository _cityRepository;
        private ICategoryRepository _categoryRepository;
        private WEBAPIContext _dbContext;

        public WEBAPIContext DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new WEBAPIContext();
                return _dbContext;
            }
        }

        public ILibraryRepository LibraryRepository
        {
            get
            {
                if (_libraryRepository == null)
                    _libraryRepository = new LibraryRepository(DbContext);
                return _libraryRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(DbContext);
                return _userRepository;
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(DbContext);
                return _userRoleRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(DbContext);
                return _bookRepository;
            }
        }

        public IBookDetailRepository BookDetailRepository
        {
            get
            {
                if (_bookDetailRepository == null)
                    _bookDetailRepository = new BookDetailRepository(DbContext);
                return _bookDetailRepository;
            }
        }


        public IProvinceRepository ProvinceRepository
        {
            get
            {
                if (_provinceRepository == null)
                    _provinceRepository = new ProvinceRepository(DbContext);
                return _provinceRepository;
            }
        }


        public ICityRepository CityRepository
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository(DbContext);
                return _cityRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(DbContext);
                return _categoryRepository;
            }
        }

        public async Task Commit() => await DbContext.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
