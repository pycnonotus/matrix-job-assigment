using System;

namespace Dto
{
    public class HeroDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? FirstTraining { get; set; } = null;
        public string SuitColor { get; set; }
        public double StartingPower { get; set; }
        public double CuretPower { get; set; }
        public int TrainedTodayTimes { get; set; }

    }
}
