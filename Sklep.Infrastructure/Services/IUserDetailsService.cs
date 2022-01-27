using Sklep.Core.Domain;
using Sklep.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Services
{
    public interface IUserDetailsService
    {
        Task<IEnumerable<UserDetailsDTO>> BrowseAll();
        Task Add(UserDetails u);
        Task Del(int id);
        Task<UserDetailsDTO> Get(int id);
        Task Update(UserDetails u, int id);
    }
}
