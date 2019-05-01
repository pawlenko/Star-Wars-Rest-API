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
    [Route("api/Planet")]
    public class PlanetController : Controller
    {
        IRepositoryWrapper _repo;

        public PlanetController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: api/Planet
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int page , [FromQuery]int count)
        {
            return Ok(new { result = (await _repo.Planet.GetPlanetRange(page, count)).Select(x=> new PlanetDTO { Id = x.Id,Name = x.Name  }),Total = await _repo.Planet.PlanetCount() });
        }

        // GET: api/Planet/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var temp = await _repo.Planet.GetPlanetById(id);

            if (temp == null)
                return BadRequest(new { error = "NOT_EXIST" });
            else 
                return Ok(new { result = new PlanetDTO { Id = temp.Id, Name = temp.Name } });
        }
        
        // POST: api/Planet
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlanetAddDTO value)
        {
            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest(new { error = "PLANET_NAME_NOT_PROVIDED" });
            }


            var exist = await _repo.Planet.CheckPlanetWithNameExist(value.Name);

            if (exist)
            {
                return BadRequest(new { error = "PLANET_NAME_TAKEN" });
            }

            var temp = await _repo.Planet.CreatePlanetAsync(value.Name);

            return Ok(new { result = new PlanetDTO { Id = temp.Id, Name = temp.Name } });

        }
        
        // PUT: api/Planet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlanetAddDTO value)
        {

            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest(new { error = "PLANET_NAME_NOT_PROVIDED" });
            }

            var temp = await _repo.Planet.GetPlanetById(id);

            if (temp == null)
                return BadRequest(new { error = "NOT_EXIST" });
            else
            {
                if (temp.Name != value.Name)
                {
                    var exist = await _repo.Planet.CheckPlanetWithNameExist(value.Name);

                    if (exist)
                    {
                        return BadRequest(new { error = "PLANET_NAME_TAKEN" });
                    }
                    else
                    {
                        temp.Name = value.Name;
                        await _repo.Planet.UpdatePlanetAsync(temp);
                       
                    }
                }

                return Ok(new { result = new PlanetDTO { Id = temp.Id, Name = temp.Name } });
            }

        }
        
        // DELETE: api/Planet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var temp = await  _repo.Planet.GetPlanetById(id);

            if (temp == null)
                return BadRequest(new { error = "NOT_EXIST" });
            else
            {
                await _repo.Planet.DeletePlanetAsync(temp);
                return Ok();
            }

        }
    }
}
