using StarWars.Domain.Entities;

namespace StarWars.Domain.Repositories.Abstract
{
    public interface ICharactersItemsRepository
    {
        IQueryable<CharacterItem> GetCharactersItems();
        CharacterItem GetCharacterItemById(Guid id);
        //CharacterItem GetCharacterItemByCodeWord(string codeWord);
        //CharacterItem GetCharacterItemByBirthdayDate(DateTime date);
        //CharacterItem GetCharacterItemByFilms(string film);
        //CharacterItem GetCharacterItemByPlanet(string planet);
        //CharacterItem GetCharacterItemBySex(string sex);
        void SaveCharacterItem(CharacterItem entity);
        void DeleteCharacterItem(Guid id);
    }
}
