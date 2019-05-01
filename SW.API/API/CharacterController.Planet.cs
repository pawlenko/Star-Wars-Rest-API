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
    [Route("api/Character/{characterID:int}/Planet")]
    public class PlanetCharacterController : Controller
    {

        IRepositoryWrapper _repo;

        public PlanetCharacterController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }


        // POST: api/PlanetCharacterController
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterPlanetAddDTO state,[FromRoute] int characterID)
        {

            var character = await _repo.Character.GetCharacterById(characterID);

            if(character == null)
                return BadRequest(new { error = "CHARACTER_NOT_EXIST" } );
            else
            {
                var planet = await _repo.Planet.GetPlanetById(state.Id);

                if (planet == null)
                    return BadRequest(new { error = "PLANET_NOT_EXIST" });
                else
                {
                     bool exist = await _repo.Planet.CheckPlanetWithCharacterExist(character, planet);
                    if (exist)
                    {
                        return Ok();
                    }
                    else
                    {
                        planet.Character.Add(character);
                        await _repo.Planet.UpdatePlanetAsync(planet);
                        return Ok();
                    }
                }

            }


        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int characterID)
        {
            var character = await _repo.Character.GetCharacterById(characterID);

            if (character == null)
                return BadRequest(new { error = "CHARACTER_NOT_EXIST" });
            else
            {
                character.PlanetId = null;
                character.Planet = null;
                await _repo.Character.UpdateCharacterAsync(character);
                return Ok();

            }

        }
    }
}
