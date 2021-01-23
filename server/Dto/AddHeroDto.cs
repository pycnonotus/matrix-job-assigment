using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class AddHeroDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SuitColor { get; set; }
        [Required]
        public double Power { get; set; }
        [Required]
        public string Ability { get; set; }



    }
}
