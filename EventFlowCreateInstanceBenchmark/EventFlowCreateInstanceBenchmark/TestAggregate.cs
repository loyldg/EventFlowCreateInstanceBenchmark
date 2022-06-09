namespace EventFlowCreateInstanceBenchmark;

public class TestAggregate : AggregateRoot<TestAggregate, TestIdentity>
{
    public TestAggregate(TestIdentity id) : base(id)
    {
    }
}