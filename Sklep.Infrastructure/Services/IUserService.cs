using Sklep.Core.Domain;
using Sklep.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> BrowseAll();
        Task Add(User u);
        Task Del(int id);
        Task<UserDTO> Get(int id);
        Task Update(User u, int id);
    }
}
