using System.ComponentModel.DataAnnotations;

namespace StarWars.Domain.Entities
{
    public class CharacterItem 
    {
        [Required]
        public string CodeWord { get; set; }
        [Display(Name = "Название страницы")]
        public override  string Name { get; set; } = "Добавление персонажа";

        [Display(Name = "Имя персонажа")]
        public override string NameOfCharacter { get; set; }

        [Display(Name = "Имя(в оригинале)")]
        public override string NameInOriginal { get; set; }

        [Display(Name = "Дата рождения")]
        public override string BirthdayDate { get; set; }

        [Display(Name = "Планета")]
        public override string Planet { get; set; }

        [Display(Name = "Пол")]
        public override string Sex { get; set; }

        [Display(Name = "Раса")]
        public override string Species { get; set; }
        [Display(Name = "Рост")]
        public override string Height { get; set; }
        [Display(Name = "Цвет волос")]
        public override string HairColor { get; set; }

        [Display(Name = "Цвет глаз")]
        public override string EyeColor { get; set; }

        [Display(Name = "Описание")]
        public override string Description { get; set; }

        [Display(Name = "Фильмы")]
        public override string Films { get; set; }


        [Display(Name = "Картинка")]
        public override string Picture { get; set; }
    }
}
