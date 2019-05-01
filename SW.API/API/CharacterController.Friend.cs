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
    [Route("api/Character/{characterID:int}/Friend")]
    public class FriendController : Controller
    {
        IRepositoryWrapper _repo;


        public FriendController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // POST: api/Friend
        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] int characterID, [FromBody] CharacterFriendAddDTO state)
        {
            var parent = await _repo.Character.GetCharacterById(characterID);

            if (parent == null)
                return BadRequest(new { error = "PARENT_CHARACTER_NOT_EXIST" });

            var child = await _repo.Character.GetCharacterById(state.Id);

            if (child == null)
                return BadRequest(new { error = "CHILD_CHARACTER_NOT_EXIST" });


            var friend = await _repo.Friend.GetFriend(parent, child);

            if (friend ==null)
                await _repo.Friend.AddFriend(parent, child);

            return Ok();
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{friendID}")]
        public async Task<IActionResult> Delete([FromRoute] int characterID, int friendID)
        {
            var parent = await _repo.Character.GetCharacterById(characterID);

            if (parent == null)
                return BadRequest(new { error = "PARENT_CHARACTER_NOT_EXIST" });

            var child = await _repo.Character.GetCharacterById(friendID);

            if (child == null)
                return BadRequest(new { error = "CHILD_CHARACTER_NOT_EXIST" });

            var friend = await _repo.Friend.GetFriend(parent, child);

            if (friend != null)
                await _repo.Friend.RemoveFriend(friend);

            return Ok();

        }
    }
}
