using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
                new SuperHero {
                Id =1 ,
                Name="Spider Man",
                FirstName="Peter" ,
                LastName="Parker",
                Place="New York"
                },
                new SuperHero {
                Id =2 ,
                Name="Iron Man",
                FirstName="Tony" ,
                LastName="Stark",
                Place="Long Island"
                }
        };





        [HttpGet("GetHeroes")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {           
            return Ok(heroes);
        }
        [HttpGet("GetSingleHero")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroById(int id)
        {
            for(int i=0;i<heroes.Count;i++)
            {
                if (heroes[i].Id == id)
                {
                    return Ok(heroes[i]);
                }
            }
            return BadRequest("Hero Not Found");
        }
        [HttpPost("AddHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
        [HttpPut("UpdateHero")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero RequestedHero)
        {
           
            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Id == RequestedHero.Id)
                {
                    heroes[i].Name= RequestedHero.Name;
                    heroes[i].Place= RequestedHero.Place;
                    heroes[i].FirstName= RequestedHero.FirstName;
                    heroes[i].LastName= RequestedHero.LastName;
                    return Ok(heroes);
                }
            }
            return BadRequest("Hero Hasnt found");
            
        }
        [HttpDelete("DeleteHero")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHeroById(int id)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Id == id)
                {
                    heroes.Remove(heroes[i]);
                    return Ok(heroes);
                }
            }
            return BadRequest("Hero Not Found");
        }
    }
}
