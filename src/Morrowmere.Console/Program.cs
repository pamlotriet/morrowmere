
using Morrowmere.Domain.Models;
using Morrowmere.Simulation.Engines;

var engine = new SimulationEngine();
var world = new WorldState();

using var cancellation = new CancellationTokenSource();
using var timer = new PeriodicTimer(
    TimeSpan.FromSeconds(5));

var sync = new object();
bool paused = false;

Console.WriteLine("Welcome to Morrowmere!");
Console.WriteLine("Commands: start, pause, step, status, exit");

// Run the input loop separately.
var inputTask = Task.Run(() =>
{
    while (!cancellation.IsCancellationRequested)
    {
        var input = Console.ReadLine()?.Trim().ToLowerInvariant();

        if (input is null or "exit")
        {
            cancellation.Cancel();
            break;
        }

        lock (sync)
        {
            switch (input)
            {
                case "pause":
                    paused = true;
                    Console.WriteLine("Simulation paused.");
                    break;

                case "start":
                    paused = false;
                    Console.WriteLine("Simulation resumed.");
                    break;

                case "step":
                    engine.AdvanceTime(world);
                    PrintTime();
                    break;

                case "status":
                    PrintTime();
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
});

try
{
    // Run the simulation independently of user input.
    while (await timer.WaitForNextTickAsync(cancellation.Token))
    {
        lock (sync)
        {
            if (!paused)
            {
                engine.AdvanceTime(world);
                PrintTime();
            }
        }
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Morrowmere has closed.");
}

await inputTask;

void PrintTime()
{
    Console.WriteLine(
        $"Day {world.Clock.Day}, Hour {world.Clock.Hour:00}:00");
}
