﻿using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PauloMorgado.Extensions.UseCases;

namespace PauloMorgado.Extensions.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    public class GetNameBenchmarks
    {
        [Benchmark]
        public object EnumGetNames() => Enum.GetName(typeof(TestEnum), TestEnum.Some);

        [Benchmark]
        public object EnumExtensionsGetNamesOf() => TestEnum.Some.GetName();
    }
}
