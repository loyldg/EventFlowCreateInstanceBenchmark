namespace EventFlowCreateInstanceBenchmark.Benchmarks;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
[RPlotExporter, RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateReadModelBenchmarks
{
    private string _testId = "testidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";
    private string _myTestId = "mytestidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";
    private IReadModelFactory<TestReadModel> _readModelFactory = null!;
    private IReadModelFactory<TestReadModel> _myReadModelFactory = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _readModelFactory =
            new ReadModelFactory<TestReadModel>(new Logger<ReadModelFactory<TestReadModel>>(new LoggerFactory()));
        _myReadModelFactory =
            new MyReadModelFactory<TestReadModel>(new Logger<MyReadModelFactory<TestReadModel>>(new LoggerFactory()));
    }

    [Benchmark(Baseline = true)]
    public TestReadModel CreateReadModelWithNew()
    {
        return new TestReadModel();
    }
    [Benchmark]
    public Task<TestReadModel> CreateReadModelWithActivator()
    {
        return _readModelFactory.CreateAsync(_testId, CancellationToken.None);
    }
    [Benchmark]
    public Task<TestReadModel> CreateMyReadModelWithFunc()
    {
        return _myReadModelFactory.CreateAsync(_myTestId, CancellationToken.None);
    }
}