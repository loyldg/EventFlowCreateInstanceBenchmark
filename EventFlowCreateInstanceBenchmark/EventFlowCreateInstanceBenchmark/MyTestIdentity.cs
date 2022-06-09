namespace EventFlowCreateInstanceBenchmark;

public class MyTestIdentity : MyIdentity<MyTestIdentity>
{
    public MyTestIdentity(string value) : base(value)
    {
    }
}