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
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        public UserDetailsService(IUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }
        public async Task Add(UserDetails u)
        {
            await _userDetailsRepository.AddAsync(u);

        }

        public async Task<IEnumerable<UserDetailsDTO>> BrowseAll()
        {
            IEnumerable<UserDetails> z = await _userDetailsRepository.BrowseAllAsync();
            if (z == null)
            {
                return null;
            }
            return z.Select(x => new UserDetailsDTO()
            {
                Id = x.Id,
                Country = x.Country,
                City = x.City,
                Adress = x.Adress,
                UserId = x.UserId
            });
        }

        public async Task Del(int id)
        {
            await _userDetailsRepository.DelAsync(id);
        }

        public async Task<UserDetailsDTO> Get(int id)
        {
            UserDetails userDetails = await _userDetailsRepository.GetAsync(id);
            if (userDetails == null)
            {
                return null;
            }
            return new UserDetailsDTO()
            {
                Id = userDetails.Id,
                Country = userDetails.Country,
                City = userDetails.City,
                Adress = userDetails.Adress,
                UserId = userDetails.UserId
            };
        }


        public async Task Update(UserDetails u, int id)
        {
            await _userDetailsRepository.UpdateAsync(u, id);
        }
    }
}
