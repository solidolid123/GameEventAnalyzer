using System;
using System.Collections.Generic;

namespace GameEventAnalyzer.Services;

public static class EventGenerator
{
    public static List<GameEvent> Generate(int count, int seed = 42)
    {
        var random = new Random(seed);
        var types = Enum.GetValues<EventType>();
        var events = new List<GameEvent>(count);

        for (int i = 0; i < count; i++)
        {
            events.Add(new GameEvent(
                Id: Guid.NewGuid(),
                Timestamp: DateTime.UtcNow.AddSeconds(random.Next(-10000, 0)),
                Type: types[random.Next(types.Length)],
                PlayerId: $"Player_{random.Next(1, 51)}",
                Score: random.Next(0, 1000),
                DurationMs: random.NextDouble() * 5000
            ));
        }
        return events;
    }
}