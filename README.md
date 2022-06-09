BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2628 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8260 CPU 2.30GHz, 2 CPU, 96 logical and 48 physical cores
.NET SDK=7.0.100-preview.4.22252.9
  [Host]   : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  .NET 6.0 : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0

|                       Method |     Mean |    Error |   StdDev | Ratio | RatioSD | Rank |  Gen 0 | Allocated |
|----------------------------- |---------:|---------:|---------:|------:|--------:|-----:|-------:|----------:|
|       CreateAggregateWithNew | 233.0 ns |  2.00 ns |  1.87 ns |  1.00 |    0.00 |    1 | 0.0203 |     352 B |
|  CreateAggregateWithNewAsync | 247.2 ns |  3.24 ns |  2.87 ns |  1.06 |    0.02 |    2 | 0.0243 |     424 B |
|      CreateAggregateWithFunc | 454.0 ns |  4.44 ns |  4.15 ns |  1.95 |    0.02 |    3 | 0.0277 |     480 B |
| CreateAggregateWithActivator | 592.4 ns | 10.83 ns | 10.13 ns |  2.54 |    0.05 |    4 | 0.0277 |     488 B |


|                         Method |        Mean |     Error |    StdDev |  Ratio | RatioSD | Rank |  Gen 0 | Allocated |
|------------------------------- |------------:|----------:|----------:|-------:|--------:|-----:|-------:|----------:|
|       CreateDomainEventWithNew |    23.20 ns |  2.573 ns |  7.086 ns |   1.00 |    0.00 |    1 |      - |      64 B |
|    CreateMyDomainEventWithFunc | 1,399.32 ns |  4.494 ns |  3.984 ns |  49.84 |    8.33 |    2 | 0.0200 |     512 B |
| CreateDomainEventWithActivator | 2,893.16 ns | 11.964 ns | 10.606 ns | 103.01 |   17.13 |    3 | 0.0800 |   1,448 B |


|                      Method |       Mean |    Error |   StdDev | Ratio | RatioSD | Rank |  Gen 0 | Allocated |
|---------------------------- |-----------:|---------:|---------:|------:|--------:|-----:|-------:|----------:|
|       CreateIdentityWithNew |   623.6 ns |  0.81 ns |  0.63 ns |  1.00 |    0.00 |    1 | 0.0143 |     256 B |
|      CreateIdentityWithFunc |   659.7 ns | 12.83 ns | 12.00 ns |  1.06 |    0.02 |    2 | 0.0143 |     256 B |
| CreateIdentityWithActivator | 1,143.2 ns | 16.16 ns | 15.11 ns |  1.83 |    0.02 |    3 | 0.0343 |     608 B |

|                       Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Rank |  Gen 0 | Allocated |
|----------------------------- |----------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|
|       CreateReadModelWithNew |  2.854 ns | 0.1133 ns | 0.1004 ns |  1.00 |    0.00 |    1 | 0.0014 |      24 B |
|    CreateMyReadModelWithFunc | 28.943 ns | 0.5359 ns | 0.5013 ns | 10.14 |    0.31 |    2 | 0.0055 |      96 B |
| CreateReadModelWithActivator | 34.042 ns | 0.4156 ns | 0.3887 ns | 11.94 |    0.44 |    3 | 0.0055 |      96 B |