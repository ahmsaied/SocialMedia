using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(Guid id);
        Task Delete(Guid id);
        Task<User> Create(User user);
        Task Update(User user);
    }
}
