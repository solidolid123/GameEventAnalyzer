using System.Collections.Generic;
using System.Linq;

namespace GameEventAnalyzer.Services;

public static class StatisticsCalculator
{
    public static List<EventStats> CalculateLinq(IEnumerable<GameEvent> events)
    {
        return events
            .GroupBy(e => new { e.Type, e.PlayerId })
            .Select(g => new EventStats(
                Type: g.Key.Type,
                PlayerId: g.Key.PlayerId,
                Count: g.Count(),
                AvgScore: g.Average(x => x.Score),
                MaxDuration: g.Max(x => x.DurationMs)
            ))
            .OrderBy(x => x.Type)
            .ThenBy(x => x.PlayerId)
            .ToList();
    }

    public static List<EventStats> CalculatePlinq(IEnumerable<GameEvent> events)
    {
        return events
            .AsParallel()
            .AsOrdered()
            .GroupBy(e => new { e.Type, e.PlayerId })
            .Select(g => new EventStats(
                Type: g.Key.Type,
                PlayerId: g.Key.PlayerId,
                Count: g.Count(),
                AvgScore: g.Average(x => x.Score),
                MaxDuration: g.Max(x => x.DurationMs)
            ))
            .OrderBy(x => x.Type)
            .ThenBy(x => x.PlayerId)
            .ToList();
    }

    public static long CalculateTotalScorePlinq(IEnumerable<GameEvent> events)
    {
        return events.AsParallel().Aggregate(
            seedFactory: () => 0L,
            updateAccumulatorFunc: (localSum, ev) => localSum + ev.Score,
            combineAccumulatorsFunc: (totalSum, localSum) => totalSum + localSum,
            resultSelector: localSum => localSum
        );
    }
}