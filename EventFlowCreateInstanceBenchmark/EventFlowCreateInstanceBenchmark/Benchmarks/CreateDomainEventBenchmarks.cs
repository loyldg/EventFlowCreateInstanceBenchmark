using EventId = EventFlow.Aggregates.EventId;

namespace EventFlowCreateInstanceBenchmark.Benchmarks;

[SimpleJob(RuntimeMoniker.Net60, invocationCount: 100000)]
[MemoryDiagnoser]
[RPlotExporter, RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateDomainEventBenchmarks
{
    private string _testId = "testidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";
    private string _myTestId = "mytestidentity-6078c18a-66b0-4d5f-a245-dafb8b85e90d";
    private TestIdentity _testIdentity = null!;
    private IMetadata _metadata = null!;
    private IMetadata _myMetadata = null!;
    private TestEvent _testEvent = null!;
    private MyTestEvent _myTestEvent = null!;
    private DateTimeOffset _timestamp;

    private IDomainEventFactory _domainEventFactory = null!;
    private IDomainEventFactory _myDomainEventFactory = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _testIdentity = new TestIdentity(_testId);

        _domainEventFactory = new DomainEventFactory();
        _myDomainEventFactory = new MyDomainEventFactory();

        _metadata = new Metadata
        {
            Timestamp = DateTimeOffset.Now,
            AggregateSequenceNumber = 1,
            AggregateName = typeof(TestAggregate).GetAggregateName().Value,
            AggregateId = _testId,
            EventId = EventId.New,
        };
        _myMetadata = new Metadata
        {
            Timestamp = DateTimeOffset.Now,
            AggregateSequenceNumber = 1,
            AggregateName = typeof(MyTestAggregate).GetAggregateName().Value,
            AggregateId = _myTestId,
            EventId = EventId.New,
        };
        _timestamp = DateTimeOffset.Now;

        _testEvent = new TestEvent(1, "1");
        _myTestEvent = new MyTestEvent(1, "1");
    }

    [Benchmark(Baseline = true)]
    public IDomainEvent CreateDomainEventWithNew()
    {
        return new DomainEvent<TestAggregate, TestIdentity, TestEvent>(_testEvent,
            _metadata,
            _timestamp,
            _testIdentity,
            1);
    }

    [Benchmark]
    public IDomainEvent CreateDomainEventWithActivator()
    {
        return _domainEventFactory.Create(_testEvent, _metadata, _testId, 1);
    }

    [Benchmark]
    public IDomainEvent CreateMyDomainEventWithFunc()
    {
        return _myDomainEventFactory.Create(_myTestEvent, _myMetadata, _myTestId, 1);
    }
}