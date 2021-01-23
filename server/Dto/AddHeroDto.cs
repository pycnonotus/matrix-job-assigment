using System.ComponentModel.DataAnnotations;
using Attribute;

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
        [Ability]
        public string Ability { get; set; }



    }
}
