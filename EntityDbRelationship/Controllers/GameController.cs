using EntityDbRelationship.Data;
using EntityDbRelationship.Models;
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
        [HttpPost]
        public async Task<ActionResult<List<Character>>> createCharacter(CharacterViewModel character)
        {
            var NewCharacter = new Character()
            {
                Name = character.Name
            };

            var backpack = new Backpack() { Description = character.Backpack.Description };
            NewCharacter.Backpack = backpack;
            _dataContext.Characters.Add(NewCharacter);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Characters.Include(c => c.Backpack).ToListAsync());

        }
    }
}
