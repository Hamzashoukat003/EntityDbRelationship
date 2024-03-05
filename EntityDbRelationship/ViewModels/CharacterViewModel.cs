using EntityDbRelationship.Data.Models;

namespace EntityDbRelationship.ViewModels
{
    public record struct CharacterViewModel(string Name,BackpackViewModel Backpack, List<WeaponViewModel>Weapons, List<FactionViewModel> Feactions );
}
