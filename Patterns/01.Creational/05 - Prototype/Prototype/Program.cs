using Prototype;

Console.Title = "Prototype";

var manager = new Manager("Cindy");
var managerClone = (Manager)manager.PersonClone(deepClone: false);
Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Kevin", managerClone);
var employeeClone = (Employee)employee.PersonClone(deepClone: true);
Console.WriteLine($"Employee was cloned: {employeeClone.Name}," +
    $" with manager {employeeClone.Manager.Name}");

// change the manager name
managerClone.Name = "Karen";
Console.WriteLine($"Employee was cloned: {employeeClone.Name}, " +
    $"with manager {employeeClone.Manager.Name}");

Console.ReadKey();