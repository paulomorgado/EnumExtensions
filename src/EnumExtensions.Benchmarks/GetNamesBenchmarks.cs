using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PauloMorgado.Extensions.UseCases;

namespace PauloMorgado.Extensions.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    public class GetNamesBenchmarks
    {
        [Benchmark]
        public object EnumGetNames() => Enum.GetNames(typeof(TestEnum));

        [Benchmark]
        public object EnumExtensionsGetNamesOf() => EnumExtensions.GetNames<TestEnum>();
    }
}
