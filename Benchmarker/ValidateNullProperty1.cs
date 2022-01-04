using System.Collections.Generic;
using System.Linq;

namespace Benchmarker
{
    public class ValidateNullProperty1 : IValidationStep
    {
        public Reading ValidateReading(Reading reading)
        {
            if (reading.Property1 == null)
            {
                return reading;
            }

            return null;
        }

        public List<Reading> ValidateReadings(List<Reading> readings)
        {
            var invalidReadings = new List<Reading>();

            foreach (var reading in readings)
            {
                if (reading.Property1 == null)
                {
                    invalidReadings.Add(reading);
                }
            }

            return invalidReadings.Any() ? invalidReadings : null;
        }
    }
}