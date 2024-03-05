using EntityDbRelationship.Data;
using EntityDbRelationship.Data.Models;
using EntityDbRelationship.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityDbRelationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public GameController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id) 
        {
            var Character = await _dataContext.Characters.Include(c => c.Backpack).Include(c => c.Weapons).Include(c => c.Factions)
                .FirstOrDefaultAsync(c => c.Id == id);
            return Ok(Character);
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> createCharacter(CharacterViewModel character)
        {
            var newCharacter = new Character()
            {
                Name = character.Name
            };

            var backpack = new Backpack() { Description = character.Backpack.Description };
            var weapons = character.Weapons.Select(x => new Weapon { Name = x.Name, Character = newCharacter }).ToList();
            var factions = character.Feactions.Select(a => new Faction { Name = a.Name, Characters = new List<Character> { newCharacter } }).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _dataContext.Characters.Add(newCharacter);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Characters.Include(c => c.Backpack).Include(c => c.Weapons).ToListAsync());

        }
    }
}
