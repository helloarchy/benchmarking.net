using System.Collections.Generic;

namespace Benchmarker
{
    public class ValidateNullProperty1 : IValidationStep
    {
        public (Reading reading, string error) ValidateReading(Reading reading)
        {
            return reading.Property1 == null ? (reading, "Is null") : (reading, "");
        }

        public List<(Reading reading, string error)> ValidateReadings(List<Reading> readings)
        {
            var invalidReadings = new List<(Reading reading, string error)>();

            foreach (var reading in readings)
            {
                if (reading == null)
                {
                    invalidReadings.Add((reading, ""));
                }
            }

            return invalidReadings;
        }
    }
}