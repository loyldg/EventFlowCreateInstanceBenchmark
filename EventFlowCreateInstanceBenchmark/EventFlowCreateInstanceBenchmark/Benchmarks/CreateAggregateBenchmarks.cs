namespace EventFlowCreateInstanceBenchmark.Benchmarks;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
[RPlotExporter, RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateAggregateBenchmarks
{
    private string _testId = "testidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";
    private string _myTestId = "mytestidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";
    private TestIdentity _testIdentity = null!;
    private MyTestIdentity _myTestIdentity = null!;

    private IAggregateFactory _aggregateFactory = null!;
    private IAggregateFactory _myAggregateFactory = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _testIdentity = new TestIdentity(_testId);
        _myTestIdentity = new MyTestIdentity(_myTestId);
        var provider = new ServiceCollection().BuildServiceProvider();
        _aggregateFactory = new AggregateFactory(provider);
        _myAggregateFactory = new MyAggregateFactory(provider, new MemoryCache(new MemoryCacheOptions()));
    }

    [Benchmark(Baseline = true)]
    public TestAggregate CreateAggregateWithNew()
    {
        return new TestAggregate(_testIdentity);
    }

    [Benchmark]
    public Task<TestAggregate> CreateAggregateWithNewAsync()
    {
        return Task.FromResult(new TestAggregate(_testIdentity));
    }


    [Benchmark]
    public Task<TestAggregate> CreateAggregateWithActivator()
    {
        return _aggregateFactory.CreateNewAggregateAsync<TestAggregate, TestIdentity>(_testIdentity);
    }

    [Benchmark]
    public Task<MyTestAggregate> CreateAggregateWithFunc()
    {
        return _myAggregateFactory.CreateNewAggregateAsync<MyTestAggregate, MyTestIdentity>(_myTestIdentity);
    }
}