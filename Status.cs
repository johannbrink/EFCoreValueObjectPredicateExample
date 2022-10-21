namespace EFCoreValueObjectPredicateExample;

public class Status : ValueObject
{
    public static readonly Status Active = new Status("Active");
    public static readonly Status Inactive = new Status("Inactive");


    public string Name { get; }
    private Status(string name)
    {
        Name = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}