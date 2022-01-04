using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;

namespace Benchmarker
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [MemoryDiagnoser]
    public class Demo
    {
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
    }
}
