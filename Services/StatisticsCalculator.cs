using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEventAnalyzer.Services.Model;

namespace GameEventAnalyzer.Services
{
    internal class StatisticsCalculator
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
                localInit: () => 0L,
                updateAccumulator: (localSum, ev) => localSum + ev.Score,
                mapLocalResult: localSum => localSum,
                aggregateResults: (totalSum, localSum) => totalSum + localSum
            );
        }
    }
}
