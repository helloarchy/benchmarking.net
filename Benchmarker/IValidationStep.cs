using System.Collections.Generic;

namespace Benchmarker
{
    public interface IValidationStep
    {
       Reading ValidateReading(Reading reading);
        List<Reading> ValidateReadings(List<Reading> readings);
    }
}