using System.Diagnostics;
using StaffsAPI.models;

namespace StaffsAPI.repos;

public class EmployeeRepository : IEmployeeRepository
{
    private StaffsContext db;

    public EmployeeRepository()
    {
        db = new StaffsContext();
    }

    public List<Employee> FindAll()
    {
        return db.Employees.ToList();
    }

    public Employee FindById(int id)
    {
        return db.Employees.Find(id);
    }

    public Employee Create(Employee employee)
    {
        db.Employees.Add(employee);
        try
        {
            db.SaveChanges();
            return employee;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.ToString());
            return null;
        }
    }

    public Employee Update(Employee employee)
    {
        Employee updated = db.Employees.Find(employee.EmployeeId);
        if (updated == null)
        {
            return null;
        }
        updated.FirstName = employee.FirstName;
        updated.LastName = employee.LastName;
        updated.Email = employee.Email;
        updated.StartingDate = employee.StartingDate;
        updated.GenderId = employee.GenderId;
        updated.DepartmentId = employee.DepartmentId;
        try
        {
            db.SaveChanges();
            return updated;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.ToString());
            return null;
        }
    }

    public Employee Delete(int id)
    {
        Employee employee = db.Employees.Find(id);
        if (employee == null)
        {
            return null;
        }
        db.Employees.Remove(employee);
        try
        {
            db.SaveChanges();
            return employee;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.ToString());
            return null;
        }
    }
}