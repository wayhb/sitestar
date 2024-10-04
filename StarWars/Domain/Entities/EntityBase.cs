using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace StarWars.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow;

        [System.ComponentModel.DataAnnotations.Required]
        public Guid Id { get; set; }
        [Display(Name = "Название страницы")]
        public virtual string Name { get; set; } = "Добавление персонажа";

        //[Display(Name = "Имя персонажа")]
        //public virtual string NameOfCharacter { get; set; }

        //[Display(Name = "Имя(в оригинале)")]
        //public virtual string NameInOriginal { get; set; }

        //[Display(Name = "Дата рождения")]
        //public virtual string BirthdayDate { get; set; }

        //[Display(Name = "Планета")]
        //public virtual string Planet { get; set; }

        //[Display(Name = "Пол")]
        //public virtual string Sex { get; set; }

        //[Display(Name = "Раса")]
        //public virtual string Species { get; set; }
        //[Display(Name = "Рост")]
        //public virtual string Height { get; set; }
        //[Display(Name = "Цвет волос")]
        //public virtual string HairColor { get; set; }

        //[Display(Name = "Цвет глаз")]
        //public virtual string EyeColor { get; set; }

        //[Display(Name = "Описание")]
        //public virtual string Description { get; set; }

        //[Display(Name = "Фильмы")]
        //public virtual string Films { get; set; }


        //[Display(Name = "Картинка")]
        //public virtual string Picture { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

    }
}
