using Sklep.Core.Domain;
using Sklep.Core.Repositories;
using Sklep.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Infrastructure.Services
{
        public class UserService : IUserService
        {
            private readonly IUserRepository _userRepository;
            public UserService(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task Add(User u)
            {
                await _userRepository.AddAsync(u);

            }

            public async Task<IEnumerable<UserDTO>> BrowseAll()
            {
                IEnumerable<User> z = await _userRepository.BrowseAllAsync();
                if (z == null)
                {
                    return null;
                }
                return z.Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname
                });
            }

            public async Task Del(int id)
            {
                await _userRepository.DelAsync(id);
            }

            public async Task<UserDTO> Get(int id)
            {
                User user = await _userRepository.GetAsync(id);
                if (user == null)
                {
                    return null;
                }
                return new UserDTO()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname
                };
            }


            public async Task Update(User u, int id)
            {
                await _userRepository.UpdateAsync(u, id);
            }
        }
}
