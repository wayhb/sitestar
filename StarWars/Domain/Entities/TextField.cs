using System.ComponentModel.DataAnnotations;

namespace StarWars.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }
        //public DateTime BirthdayDate { get; set; }
        //public string Film { get; set; }
        //public string Planet { get; set; }

        //public string Sex { get; set; }
        [Display(Name = "Название страницы")]
        public override string Name { get; set; } = "Каталог персонажей StarWars";

        
    }
}
