using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserContext _userContext;

        public UsersRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> Create(User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(Guid id)
        {
            var deletedUser = await _userContext.Users.FindAsync(id);
            _userContext.Users.Remove(deletedUser);
            await _userContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _userContext.Users.ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            _userContext.Entry(user).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
        }
    }
}
