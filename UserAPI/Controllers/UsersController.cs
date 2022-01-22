using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _usersRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _usersRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            var newUsers = await _usersRepository.Create(user);
            return Ok(newUsers);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] User user)
        {
            if(id != user.ID)
            {
                return BadRequest();
            }
            await _usersRepository.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletedUser = await _usersRepository.Get(id);
            if(deletedUser == null)
            {
                return BadRequest();
            }
            await _usersRepository.Delete(deletedUser.ID);
            return Ok();
        }
    }
}
