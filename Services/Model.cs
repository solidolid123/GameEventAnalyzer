namespace GameEventAnalyzer;

public enum EventType { Kill, Death, ItemPickup, LevelUp, QuestComplete }

public record GameEvent(
    Guid Id,
    DateTime Timestamp,
    EventType Type,
    string PlayerId,
    int Score,
    double DurationMs
);

public record EventStats(
    EventType Type,
    string PlayerId,
    int Count,
    double AvgScore,
    double MaxDuration
);