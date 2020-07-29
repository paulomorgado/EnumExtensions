using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PauloMorgado.Extensions.UseCases;

namespace PauloMorgado.Extensions.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    public class HasFlagsBenchmarks
    {
        [Benchmark]
        public bool EnumHasFlag8() => TestEnum8.Some.HasFlag(TestEnum8.Other);

        [Benchmark]
        public bool EnumExtensionsHasFlagsOfT8() => EnumExtensions.HasFlag(TestEnum8.Some, TestEnum8.Other);

        [Benchmark]
        public bool EnumHasFlag16() => TestEnum16.Some.HasFlag(TestEnum16.Other);

        [Benchmark]
        public bool EnumExtensionsHasFlagsOfT16() => EnumExtensions.HasFlag(TestEnum16.Some, TestEnum16.Other);

        [Benchmark]
        public bool EnumHasFlag32() => TestEnum32.Some.HasFlag(TestEnum32.Other);

        [Benchmark]
        public bool EnumExtensionsHasFlagsOfT32() => EnumExtensions.HasFlag(TestEnum32.Some, TestEnum32.Other);

        [Benchmark]
        public bool EnumHasFlag64() => TestEnum64.Some.HasFlag(TestEnum64.Other);

        [Benchmark]
        public bool EnumExtensionsHasFlagsOfT64() => EnumExtensions.HasFlag(TestEnum64.Some, TestEnum64.Other);
    }
}
