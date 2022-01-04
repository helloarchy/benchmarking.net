using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;
using Moq;

namespace Benchmarker
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [MemoryDiagnoser]
    public class Demo
    {
        private List<Reading> _invalidReadings;
        private List<IValidationStep> _validationSteps;

        public Demo()
        {
            _invalidReadings = GenerateReadings(2000);
            _validationSteps = GenerateValidationSteps(10);
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

        [Benchmark]
        public List<Reading> IterateBySteps()
        {
            
        }
        
        
        [Benchmark]
        public string GetFullStringNormally()
        {
            string output = "";

            for (int i = 0; i < 100; i++)
            {
                output += i;
            }

            return output;
        }

        [Benchmark]
        public string GetFullStringWithStringBuilder()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                output.Append(i);
            }

            return output.ToString();
        }

        private List<Reading> GenerateReadings(int n)
        {
            var readings = new List<Reading>();
            
            for (var i = 0; i < n; i++)
            {
                var reading = new Reading
                {
                    Property1 = It.IsAny<string>(),
                    Property2 = It.IsAny<string>(),
                    Property3 = It.IsAny<string>()
                };
                
                readings.Add(reading);
            }

            return readings;
        }
    }
}
