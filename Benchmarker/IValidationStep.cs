using System.Collections.Generic;

namespace Benchmarker
{
    public interface IValidationStep
    {
        public (Reading reading, string error) ValidateReading(Reading reading);
        public List<(Reading reading, string error)> ValidateReadings(List<Reading> readings);
    }
}