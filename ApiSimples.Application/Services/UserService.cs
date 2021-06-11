using ApiSimples.Application.Data.Repository;
using ApiSimples.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiSimples.Application.Services
{
    public class UserService
    {
        private UserRepository Repository;
        public UserService(UserRepository repository)
        {
            Repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }

        public async Task<User> Get(Guid id)
        {
            return await Repository.SelectAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Repository.SelectAsync();
        }

        public async Task<User> Post(User user)
        {
            return await Repository.InsertAsync(user);
        }

        public async Task<User> Put(User user)
        {
            return await Repository.UpdateAsync(user);
        }
    }
}
