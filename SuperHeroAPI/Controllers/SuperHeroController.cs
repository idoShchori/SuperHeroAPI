using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }



        [HttpGet("GetHeroes")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpGet("GetSingleHero")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return BadRequest("Hero Not Found");
            return BadRequest("Hero Not Found");
            return Ok(hero);

        }
        
        [HttpPost("AddHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPut("UpdateHero")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero RequestedHero)
        {

            var dbHero = await _context.SuperHeroes.FindAsync(RequestedHero.Id);
            if (dbHero == null)
                return BadRequest("Hero Not Found");
            {

                dbHero.Name = RequestedHero.Name;
                dbHero.Place = RequestedHero.Place;
                dbHero.FirstName = RequestedHero.FirstName;
                dbHero.LastName = RequestedHero.LastName;
                await _context.SaveChangesAsync();

                return Ok(await _context.SuperHeroes.ToListAsync());

            }
        }
            [HttpDelete("DeleteHero")]
            public async Task<ActionResult<List<SuperHero>>> DeleteHeroById(int id)
            {
                var hero = await _context.SuperHeroes.FindAsync(id);

                if (hero == null)
                    return BadRequest("Hero Not Found");
                return BadRequest("Hero Not Found");
                _context.SuperHeroes.Remove(hero);
                await _context.SaveChangesAsync();

            }
        
    }
};
