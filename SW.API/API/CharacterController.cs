using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SW.Business.Interface;
using SW.Business.DTO;

namespace SW.API.API
{
    [Produces("application/json")]
    [Route("api/Character")]
    public class CharacterController : Controller
    {

        IRepositoryWrapper _repo;

        public CharacterController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }


        // GET: api/Character
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int index, [FromQuery]int count)
        {
            var temp = (await _repo.Character.GetCharacterRange(index, count)).Select(x => new CharacterDTO
            {
                Name = x.Name,
                Planet = x.Planet?.Name,
                Episodes = x.Episodes.Select(c => c.Episode).Select(c => c.Name).ToList(),
                Friends = x.Friends.Select(c => c.Friends).Select(c =>  c.Name ).Concat(x.FriendFor.Select(c => c.Character).Select(c =>  c.Name )).ToArray(),
                
            });

            return Ok(new { result = temp });
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var temp = (await _repo.Character.GetCharacterById(id));


            if (temp != null)
                return BadRequest(new { error = "CHARACTER_NOT_EXIST" });
            else
            {


                return Ok(new
                {
                    result = new CharacterDTO
                    {
                        Name = temp.Name,
                        Planet = temp.Planet?.Name,
                        Episodes = temp.Episodes.Select(c => c.Episode).Select(c => c.Name).ToList(),
                        Friends = temp.Friends.Select(c => c.Friends).Select(c => c.Name).Concat(temp.FriendFor.Select(c => c.Character).Select(c => c.Name)).ToArray(),
                    }
                });

            }
        }


        // POST: api/Character
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterAddDTO value)
        {
            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest(new { error = "CHARACTER_NAME_NOT_PROVIDED" });
            }



            var temp = await _repo.Character.CreateCharacterAsync(value.Name);

            return Ok(new
            {
                result = new CharacterDTO
                {
                    Name = temp.Name,
                }
            });

        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CharacterAddDTO value)
        {

            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest(new { error = "CHARACTER_NAME_NOT_PROVIDED" });
            }

            var temp = await _repo.Character.GetCharacterById(id);

            if (temp == null)
                return BadRequest(new { error = "CHARACTER_EXIST" });
            else
            {
                if (temp.Name != value.Name)
                {
                        temp.Name = value.Name;
                        await _repo.Character.UpdateCharacterAsync(temp);
                }

                return Ok(new
                {
                    result = new CharacterDTO
                    {
                        Name = temp.Name,
                        Planet = temp.Planet?.Name,
                        Episodes = temp.Episodes.Select(c => c.Episode).Select(c => c.Name).ToList(),
                        Friends = temp.Friends.Select(c => c.Friends).Select(c => c.Name).Concat(temp.FriendFor.Select(c => c.Character).Select(c => c.Name)).ToArray(),
                    }
                });
            }
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var temp = (await _repo.Character.GetCharacterById(id));


            if (temp != null)
                return BadRequest(new { error = "CHARACTER_NOT_EXIST" });
            else
            {

                await _repo.Character.DeleteCharacterAsync(temp);
                return Ok();
            }
        }


    }
}
