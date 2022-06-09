namespace EventFlowCreateInstanceBenchmark;

public class MyTestAggregate : AggregateRoot<MyTestAggregate, MyTestIdentity>
{
    public MyTestAggregate(MyTestIdentity id) : base(id)
    {
    }
}