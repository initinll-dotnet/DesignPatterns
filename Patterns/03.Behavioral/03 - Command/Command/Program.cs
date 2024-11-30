using Command;

Console.Title = "Command";

Employee employee1 = new(id: 111, name: "Kevin");
Employee employee2 = new(id: 222, name: "Clara");
Employee employee3 = new(id: 333, name: "Tom");

CommandManager commandManager = new();
IEmployeeManagerRepository repository = new EmployeeManagerRepository();

AddEmployeeToManagerList command1 = new AddEmployeeToManagerList(
    employeeManagerRepository: repository,
    managerId: 1,
    employee: employee1);

AddEmployeeToManagerList command2 = new AddEmployeeToManagerList(
    employeeManagerRepository: repository,
    managerId: 1,
    employee: employee2);

AddEmployeeToManagerList command3 = new AddEmployeeToManagerList(
    employeeManagerRepository: repository,
    managerId: 2,
    employee: employee3);

AddEmployeeToManagerList command4 = new AddEmployeeToManagerList(
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