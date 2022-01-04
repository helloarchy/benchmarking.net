using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Moq;

namespace Benchmarker
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [MemoryDiagnoser]
    public class ReadingService
    {
        private readonly List<Reading> _readings;
        private readonly List<IValidationStep> _validationSteps;

        public ReadingService()
        {
            _readings = GenerateReadings(2000);
            _validationSteps = GenerateValidationSteps(10);
        }

        [Benchmark]
        public List<Reading> IterateBySteps()
        {
            var validReadings = _readings.ToList();
            var invalidReadings = new List<Reading>();
            foreach (var validationStep in _validationSteps)
            {
                var validationResults = validationStep.ValidateReadings(_readings);
                if (validationResults != null)
                {
                    validReadings.RemoveAll(x => validationResults.Contains(x));
                    invalidReadings.AddRange(validationResults);
                }
            }

            return invalidReadings;
        }

        [Benchmark]
        public List<Reading> IterateByReadings()
        {
            var invalidReadings = new List<Reading>();
            foreach (var reading in _readings)
            {
                foreach (var validationStep in _validationSteps)
                {
                    var invalidReading = validationStep.ValidateReading(reading);
                    if (invalidReading != null)
                    {
                        invalidReadings.Add(invalidReading);
                    }
                }
            }

            return invalidReadings;
        }

        private List<Reading> GenerateReadings(int n)
        {
            var readings = new List<Reading>();
            var random = new Random();

            for (var i = 0; i < n; i++)
            {
                var isNull = random.Next(2) == 0;
                var reading = new Reading
                {
                    Property1 = isNull ? null : "Not null",
                    Property2 = "Not null",
                    Property3 = "Not null"
                };

                readings.Add(reading);
            }

            return readings;
        }

        private List<IValidationStep> GenerateValidationSteps(int n)
        {
            var validationSteps = new List<IValidationStep>();

            for (var i = 0; i < n; i++)
            {
                var validationStep = new ValidateNullProperty1();
                validationSteps.Add(validationStep);
            }

            return validationSteps;
        }
    }
}