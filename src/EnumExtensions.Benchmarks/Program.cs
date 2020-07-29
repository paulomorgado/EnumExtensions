using BenchmarkDotNet.Running;
using PauloMorgado.Extensions.Benchmarks;

namespace EnumExtensions.Benchmarks
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(
                new BenchmarkRunInfo[]
                {
                    BenchmarkConverter.TypeToBenchmarks(typeof(GetNameBenchmarks)),
                    BenchmarkConverter.TypeToBenchmarks(typeof(GetNamesBenchmarks)),
                    BenchmarkConverter.TypeToBenchmarks(typeof(GetValuesBenchmarks)),
                    BenchmarkConverter.TypeToBenchmarks(typeof(HasFlagsBenchmarks)),
                    BenchmarkConverter.TypeToBenchmarks(typeof(IsDefinedBenchmarks)),
                });
            ;
        }
    }
}
