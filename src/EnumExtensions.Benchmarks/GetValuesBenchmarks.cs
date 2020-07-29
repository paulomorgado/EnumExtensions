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
    public class GetValuesBenchmarks
    {

        [Benchmark]
        public object EnumGetValues() => (TestEnum[])Enum.GetValues(typeof(TestEnum));

        [Benchmark]
        public object EnumExtensionsGetValuesOf() => EnumExtensions.GetValues<TestEnum>();
    }
}
