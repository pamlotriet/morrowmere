using System;
using Morrowmere.Domain.Models;
namespace Morrowmere.Simulation.Engines
{
    public class SimulationEngine
    {
        public void AdvanceTime(WorldState world)
        {
            if (world == null)
                throw new ArgumentNullException(nameof(world));
            world.Clock.AdvanceTime();
        }
    }
}
