namespace EventFlowCreateInstanceBenchmark;

public class MyTestEvent : AggregateEvent<MyTestAggregate, MyTestIdentity>
{
    public MyTestEvent(int id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}