using StarWars.Domain.Repositories.Abstract;

namespace StarWars.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public ICharactersItemsRepository CharacterItems { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, ICharactersItemsRepository charactersItemsRepository) 
        { 
            TextFields = textFieldsRepository;
            CharacterItems = charactersItemsRepository;
        }

    }
}
