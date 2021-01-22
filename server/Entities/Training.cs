using System;

namespace Entities
{
    public class Training
    {
        public Guid Id { get; set; }
        public Hero Hero { get; set; }
        public Guid HeroId { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;


    }
}
