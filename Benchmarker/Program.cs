using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace Benchmarker
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = BenchmarkRunner.Run<Demo>();
        }
    }
}
