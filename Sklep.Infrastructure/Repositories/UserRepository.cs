using Sklep.Core.Domain;
using Sklep.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(User u)
        {
            try
            {
                _appDbContext.User.Add(u);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<User>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.User);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.User.Remove(_appDbContext.User.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<User> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.User.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return null;
        }

        public async Task UpdateAsync(User u, int id)
        {
            try
            {
                var z = _appDbContext.User.FirstOrDefault(x => x.Id == id);
                z.Name = u.Name;
                z.Surname = u.Surname;
                z.UserDetails = u.UserDetails;
                z.Transactions = u.Transactions; 
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
