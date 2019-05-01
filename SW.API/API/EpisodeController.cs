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
    [Route("api/Episode")]
    public class EpisodeController : Controller
    {
        IRepositoryWrapper _repo;

        public EpisodeController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int page, [FromQuery]int count)
        {
            return Ok(new { result = await _repo.Episode.GetEpisodeRange(page, count), Total = await _repo.Episode.EpisodeCount() });
        }

        // GET: api/Episode/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var temp = await _repo.Episode.GetEpisodeById(id);

            if (temp == null)
                return BadRequest(new { error = "NOT_EXIST" });
            else
                return Ok(new { result = new EpisodeDTO { Id = temp.Id, Name = temp.Name } });
        }

        // POST: api/Episode
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EpisodeAddDTO value)
        {
            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest(new { error = "PLANET_NAME_NOT_PROVIDED" });
            }


            var exist = await _repo.Episode.CheckEpisodeWithNameExist(value.Name);

            if (exist)
            {
                return BadRequest(new { error = "PLANET_NAME_TAKEN" });
            }

            var temp = await _repo.Episode.CreateEpisodeAsync(value.Name);

            return Ok(new { result = new EpisodeDTO { Id = temp.Id, Name = temp.Name } });

        }

        // PUT: api/Episode/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EpisodeAddDTO value)
        {

            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest(new { error = "PLANET_NAME_NOT_PROVIDED" });
            }

            var temp = await _repo.Episode.GetEpisodeById(id);

            if (temp == null)
                return BadRequest(new { error = "NOT_EXIST" });
            else
            {
                if (temp.Name != value.Name)
                {
                    var exist = await _repo.Episode.CheckEpisodeWithNameExist(value.Name);

                    if (exist)
                    {
                        return BadRequest(new { error = "PLANET_NAME_TAKEN" });
                    }
                    else
                    {
                        temp.Name = value.Name;
                        await _repo.Episode.UpdateEpisodeAsync(temp);

                    }
                }

                return Ok(new { result = new EpisodeDTO { Id = temp.Id, Name = temp.Name } });
            }

        }

        // DELETE: api/Episode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var temp = await _repo.Episode.GetEpisodeById(id);

            if (temp == null)
                return BadRequest(new { error = "NOT_EXIST" });
            else
            {
                await _repo.Episode.DeleteEpisodeAsync(temp);
                return Ok();
            }

        }
    }
}
