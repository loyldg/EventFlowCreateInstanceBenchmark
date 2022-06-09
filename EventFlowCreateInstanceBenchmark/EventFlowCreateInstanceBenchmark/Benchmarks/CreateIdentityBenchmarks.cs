namespace EventFlowCreateInstanceBenchmark.Benchmarks;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
[RPlotExporter, RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateIdentityBenchmarks
{
    private string _testId = "testidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";
    private string _myTestId = "mytestidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";

    [Benchmark(Baseline = true)]
    public TestIdentity CreateIdentityWithNew()
    {
        return new TestIdentity(_testId);
    }

    [Benchmark]
    public MyTestIdentity CreateIdentityWithFunc()
    {
        return MyTestIdentity.With(_myTestId);
    }

    [Benchmark]
    public TestIdentity CreateIdentityWithActivator()
    {
        return TestIdentity.With(_testId);
    }
}