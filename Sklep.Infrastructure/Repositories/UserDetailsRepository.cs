using Sklep.Core.Domain;
using Sklep.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Repositories
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private AppDbContext _appDbContext;
        public UserDetailsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(UserDetails u)
        {
            try
            {
                _appDbContext.UserDetails.Add(u);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<UserDetails>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.UserDetails);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.UserDetails.Remove(_appDbContext.UserDetails.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<UserDetails> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.UserDetails.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return null;
        }

        public async Task UpdateAsync(UserDetails u, int id)
        {
            try
            {
                var z = _appDbContext.UserDetails.FirstOrDefault(x => x.Id == id);
                z.Country = u.Country;
                z.City = u.City;
                z.Adress = u.Adress;
                z.User = u.User;
                z.UserId = u.UserId;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
