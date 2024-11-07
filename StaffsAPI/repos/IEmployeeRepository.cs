using StaffsAPI.models;

namespace StaffsAPI.repos;

public interface IEmployeeRepository
{
    List<Employee> FindAll();
    Employee FindById(int id);
    Employee Create(Employee employee);
    Employee Update(Employee employee);
    Employee Delete(int id); 
}