using System.Text.Json;

namespace Prototype;

/// <summary>
/// Prototype
/// </summary>
public abstract class Person
{
    public abstract string Name { get; set; }

    public abstract Person PersonClone(bool deepClone);
}

/// <summary>
/// ConcretePrototype1
/// </summary>
public class Manager : Person
{
    public Manager(string name)
    {
        Name = name;
    }

    public override string Name { get; set; }

    public override Person PersonClone(bool deepClone = false)
    {
        if (deepClone)
        {
            var objectAsJson = JsonSerializer.Serialize(this);

            return JsonSerializer.Deserialize<Manager>(objectAsJson)!;
        }

        return (Person)MemberwiseClone();
    }
}

/// <summary>
/// ConcretePrototype2
/// </summary>
public class Employee : Person
{
    public Employee(string name, Manager manager)
    {
        Name = name;
        Manager = manager;
    }
    public Manager Manager { get; set; }
    public override string Name { get; set; }

    public override Person PersonClone(bool deepClone = false)
    {
        if (deepClone)
        {
            var objectAsJson = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Employee>(objectAsJson)!;
        }
        return (Person)MemberwiseClone();
    }
}