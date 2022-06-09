namespace EventFlowCreateInstanceBenchmark;

public class TestEvent : AggregateEvent<TestAggregate, TestIdentity>
{
    public TestEvent(int id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}