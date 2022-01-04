# Benchmarking .NET

Exploring benchmarking within .NET.

## Benchmarks
When comparing iterating over a list of fictional meter readings and checking against
validation steps for each of them.

### Iterate By Steps
For each validation step, loop over the entire collection of readings and check each.
On completion of each step, update the collection list to remove invalid readings.
Finally, return the collection of invalid readings.

### Iterate By Readings
For each reading, loop over the validation steps. For each failed validation, add
the reading to a list of invalid readings. Finally, return the list of invalid readings.

|            Method |                  Job |              Runtime |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|------------------ |--------------------- |--------------------- |------------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|
|    IterateBySteps |             .NET 5.0 |             .NET 5.0 | 26,618.5 us | 429.90 us | 358.99 us |  0.65 |    0.01 | 31.2500 | 31.2500 | 31.2500 |    418 KB |
|    IterateBySteps | .NET Framework 4.7.2 | .NET Framework 4.7.2 | 40,691.7 us | 561.85 us | 498.07 us |  1.00 |    0.00 |       - |       - |       - |    493 KB |
|                   |                      |                      |             |           |           |       |         |         |         |         |           |
| IterateByReadings |             .NET 5.0 |             .NET 5.0 |    209.1 us |   3.05 us |   2.85 us |  1.01 |    0.02 | 41.5039 | 41.5039 | 41.5039 |    256 KB |
| IterateByReadings | .NET Framework 4.7.2 | .NET Framework 4.7.2 |    207.4 us |   4.11 us |   4.04 us |  1.00 |    0.00 | 41.5039 | 41.5039 | 41.5039 |    257 KB |

### Key
- Mean      : Arithmetic mean of all measurements
- Error     : Half of 99.9% confidence interval
- StdDev    : Standard deviation of all measurements
- Ratio     : Mean of the ratio distribution ([Current]/[Baseline])
- RatioSD   : Standard deviation of the ratio distribution ([Current]/[Baseline])
- Gen 0     : GC Generation 0 collects per 1000 operations
- Gen 1     : GC Generation 1 collects per 1000 operations
- Gen 2     : GC Generation 2 collects per 1000 operations
- Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
- 1 us      : 1 Microsecond (0.000001 sec)
