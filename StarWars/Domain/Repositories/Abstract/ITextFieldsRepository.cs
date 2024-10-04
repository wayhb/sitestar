using StarWars.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StarWars.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        //TextField GetTextFieldByBirthdayDate(DateTime date);
        //TextField GetTextFieldByFilms(string film);
        //TextField GetTextFieldByPlanet(string planet);
        //TextField GetTextFieldBySex(string sex);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
