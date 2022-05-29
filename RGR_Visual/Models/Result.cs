using System;
using System.Collections.Generic;

namespace RGR_Visual.Models
{
    public partial class Result
    {
        public string? Horse { get; set; }
        public string? Date { get; set; }
        public long? RaceNumber { get; set; }
        public string? Racecourse { get; set; }
        public long? FinishPosition { get; set; }
        public string? DistanceBetween { get; set; }
        public string? Jockey { get; set; }

        public virtual Horse? HorseNavigation { get; set; }
        public virtual Jockey? JockeyNavigation { get; set; }
        public virtual Race? Race { get; set; }

        public Result()
        {
            Horse = "";
            Date = "";
            RaceNumber = 0;
            Racecourse = "";
            FinishPosition = 0;
            DistanceBetween = "";
            Jockey = "";
        }
        public static string[] GetAttr()
        {
            return new[] { "FinishPosition", "DistanceBetween" };
        }
    }
}
