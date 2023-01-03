using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        {
                }
        };





        [HttpGet("GetHeroes")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {           
        }
        [HttpGet("GetSingleHero")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroById(int id)
        {
            return BadRequest("Hero Not Found");
                   return Ok(hero); 

        }
           
        
        [HttpPost("AddHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
        }
        [HttpPut("UpdateHero")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero RequestedHero)
        {
           
                {
            }
            
        }
        [HttpDelete("DeleteHero")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHeroById(int id)
        {
            return BadRequest("Hero Not Found");
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());

        }
    }
}
