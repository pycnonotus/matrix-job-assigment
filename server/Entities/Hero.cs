using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Hero
    {
        [Required]
        public Guid Id { get; set; }
        //to do add abilty after i check with Rauvan if it a list or a "boolean" 
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime FirstTraining { get; set; }
        public string Color { get; set; }
        [Required]
        public double StartingPower { get; set; }
        public double CuretPower { get; set; }
        public AppUser Trainer { get; set; }
        public String TrainerId { get; set; }









    }
}
