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
    [Route("api/Character/{characterID:int}/Episode")]
    public class EpisodeCharacterController : Controller
    {

        IRepositoryWrapper _repo;

        public EpisodeCharacterController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }


      
        
        // POST: api/EpisodeCharacter
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CharacterEpisodeAddDTO state,[FromRoute] int characterID)
        {

            var character =  await _repo.Character.GetCharacterById(characterID);

            if (character == null)
                return BadRequest(new { error = "CHARACTER_NOT_EXIST" });

            var episode =  await _repo.Episode.GetEpisodeById(state.Id);

            if (character == null)
                return BadRequest(new { error = "EPISODE_NOT_EXIST" });

            var characterEpisode = await _repo.CharacterEpisode.GetEpisode(character, episode);

            if (characterEpisode == null)
                await _repo.CharacterEpisode.AddEpisode(character, episode);


            return Ok();

        }
        
       
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{episodeID}")]
        public async Task<IActionResult> Delete(int episodeID, [FromRoute] int characterID)
        {

            var character = await _repo.Character.GetCharacterById(characterID);

            if (character == null)
                return BadRequest(new { error = "CHARACTER_NOT_EXIST" });

            var episode = await _repo.Episode.GetEpisodeById(episodeID);

            if (character == null)
                return BadRequest(new { error = "EPISODE_NOT_EXIST" });

            var characterEpisode = await _repo.CharacterEpisode.GetEpisode(character, episode);

            if (characterEpisode != null)
                await _repo.CharacterEpisode.RemoveEpisode(characterEpisode);


            return Ok();

        }
    }
}
