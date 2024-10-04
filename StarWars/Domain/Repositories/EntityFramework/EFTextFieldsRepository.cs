using StarWars.Domain.Entities;
using StarWars.Domain.Repositories.Abstract;
using System.Diagnostics;

namespace StarWars.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context) { this.context = context; }
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id});
            context.SaveChanges();
        }

        //public TextField GetTextFieldByBirthdayDate(DateTime date)
        //{
        //    throw new NotImplementedException();
        //}

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        //public TextField GetTextFieldByFilms(string film)
        //{
        //    throw new NotImplementedException();
        //}

        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        //public TextField GetTextFieldByPlanet(string planet)
        //{
        //    throw new NotImplementedException();
        //}

        //public TextField GetTextFieldBySex(string sex)
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
