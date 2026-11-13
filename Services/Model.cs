using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEventAnalyzer.Services
{
    internal class Model
    {
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
    }
}
