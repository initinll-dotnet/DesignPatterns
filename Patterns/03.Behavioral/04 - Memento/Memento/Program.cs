using Memento;

Console.Title = "Command";

Employee employee1 = new(id: 111, name: "Kevin");
Employee employee2 = new(id: 222, name: "Clara");
Employee employee3 = new(id: 333, name: "Tom");

CommandManager commandManager = new();
IEmployeeManagerRepository repository = new EmployeeManagerRepository();

AddEmployeeToManagerListCommand command1 = new(
    employeeManagerRepository: repository,
    managerId: 1,
    employee: employee1);

AddEmployeeToManagerListCommand command2 = new(
    employeeManagerRepository: repository,
    managerId: 1,
    employee: employee2);

AddEmployeeToManagerListCommand command3 = new(
    employeeManagerRepository: repository,
    managerId: 2,
    employee: employee3);

AddEmployeeToManagerListCommand command4 = new(
    employeeManagerRepository: repository,
    managerId: 2,
    employee: employee1);

commandManager.Invoke(command1);
repository.WriteDataStore();

commandManager.Undo();
repository.WriteDataStore();

commandManager.Invoke(command2);
repository.WriteDataStore();

commandManager.Invoke(command3);
repository.WriteDataStore();

// try adding the same employee again
commandManager.Invoke(command4);
repository.WriteDataStore();

commandManager.UndoAll();
repository.WriteDataStore();

Console.ReadKey();