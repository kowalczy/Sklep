using Sklep.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Core.Repositories
{
    public interface IUserDetailsRepository
    {
        Task<IEnumerable<UserDetails>> BrowseAllAsync();
        Task<UserDetails> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(UserDetails userDetails, int id);
        Task AddAsync(UserDetails userDetails);
    }
}
