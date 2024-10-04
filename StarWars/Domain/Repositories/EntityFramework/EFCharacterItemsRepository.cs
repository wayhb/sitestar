using StarWars.Domain.Entities;
using StarWars.Domain.Repositories.Abstract;

namespace StarWars.Domain.Repositories.EntityFramework
{
    public class EFCharacterItemsRepository : ICharactersItemsRepository
    {
        private readonly AppDbContext context;
        public EFCharacterItemsRepository(AppDbContext context) { this.context = context; }
        public void DeleteCharacterItem(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        //public CharacterItem GetCharacterItemByBirthdayDate(DateTime date)
        //{
        //    throw new NotImplementedException();
        //}

        public CharacterItem GetCharacterItemByCodeWord(string codeWord)
        {
            return context.CharacterItems.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        //public CharacterItem GetCharacterItemByFilms(string film)
        //{
        //    throw new NotImplementedException();
        //}

        public CharacterItem GetCharacterItemById(Guid id)
        {
            return context.CharacterItems.FirstOrDefault(x => x.Id == id);
        }

        //public CharacterItem GetCharacterItemByPlanet(string planet)
        //{
        //    throw new NotImplementedException();
        //}

        //public CharacterItem GetCharacterItemBySex(string sex)
        //{
        //    throw new NotImplementedException();
        //}

        public IQueryable<CharacterItem> GetCharactersItems()
        {
            return context.CharacterItems;
        }

        public void SaveCharacterItem(CharacterItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
