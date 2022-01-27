using Sklep.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> BrowseAllAsync();
        Task<User> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(User user, int id);
        Task AddAsync(User user);
    }
}
