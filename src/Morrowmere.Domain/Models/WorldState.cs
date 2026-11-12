using System;
using System.ComponentModel.DataAnnotations;
namespace Morrowmere.Domain.Models
{
    public class WorldState
    {
        // TODO: Switch to fluent validation at later stage
        [Range(0, 100)]
        public int RealityStability { get; set; }
        [Range(0, 100)]
        public int PublicPatience { get; set; }
        [Range(0, 100)]
        public int MagicDebt { get; set; }
        public SimulationClock Clock { get; } = new(1,1);
    }
}