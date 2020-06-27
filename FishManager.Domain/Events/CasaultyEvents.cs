using System;
using FishManager.Domain.Entities;

namespace FishManager.Domain.Events
{
    public static class CasaultyEvents
    {
        public static Casualty Report(this Casualty casualty, CasualtyCause cause, Species species, int amount, DateTime timestamp)
        {
            casualty.CasualtyCause = cause;
            casualty.Species = species;
            casualty.Timestamp = timestamp;
            casualty.Count = amount;
            return casualty;
        }
    }
}