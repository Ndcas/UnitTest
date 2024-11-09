using System.Reflection;
using StaffsAPI.models;
using StaffsAPI.repos;

namespace Tests;

public class EmployeeRepositoryTest
{
    private IEmployeeRepository employeeRepository;
    private List<Employee> defaultEmployees;

    public EmployeeRepositoryTest()
    {
        employeeRepository = new EmployeeRepository();
        defaultEmployees = new List<Employee>();
        defaultEmployees.Add(new Employee()
        {
            EmployeeId = 1,
            FirstName = "Hung",
            LastName = "Nguyen",
            GenderId = 1,
            DepartmentId = 1,
            StartingDate = new DateTime(2024, 07, 08)
        });
        defaultEmployees.Add(new Employee()
        {
            EmployeeId = 2,
            FirstName = "Duy",
            LastName = "Nguyen",
            Email = "nduy@gmail.com",
            GenderId = 1,
            DepartmentId = 2,
            StartingDate = new DateTime(2024, 01, 01)
        });
        defaultEmployees.Add(new Employee()
        {
            EmployeeId = 3,
            FirstName = "Chau",
            LastName = "Nguyen",
            GenderId = 2,
            DepartmentId = 3,
            Email = "cnguyen@gmail.com",
            StartingDate = new DateTime(2020, 02, 12)
        });
        defaultEmployees.Add(new Employee()
        {
            EmployeeId = 4,
            FirstName = "Khoa",
            LastName = "Vo",
            GenderId = 1,
            DepartmentId = 2,
            StartingDate = new DateTime(2015, 12, 12)
        });
    }

    [Fact]
    public void FindAll()
    {
        List<Employee> result = employeeRepository.FindAll();
        bool valid = (4 == result.Count);
        if (valid)
        {
            foreach (Employee employee in result)
            {
                if (!defaultEmployees.Any(e => CompareEmployee(employee, e)))
                {
                    valid = false;
                    break;
                }
            }
        }
        Assert.True(valid);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void FindById(int id)
    {
        Employee expected = id <= defaultEmployees.Count ? defaultEmployees[id - 1] : null;
        Assert.True(CompareEmployee(expected, employeeRepository.FindById(id)));
    }

    [Fact]
    public void Create()
    {
        Employee employee = new Employee()
        {
            EmployeeId = 5,
            FirstName = "TestF",
            LastName = "TestL",
            DepartmentId = 1,
            GenderId = 2,
            Email = "test@gmail.com",
            StartingDate = new DateTime(2024, 2, 3)
        };
        Employee result = employeeRepository.Create(employee);
        Assert.True(CompareEmployee(employee, result));
    }

    [Fact]
    public void Update()
    {
        Employee employee = employeeRepository.FindById(5);
        employee.FirstName = "Edited test";
        employee.LastName = "Edited testl";
        employee.Email = null;
        employee.DepartmentId = 3;
        employee.GenderId = 1;
        employee.StartingDate = new DateTime(2024, 12, 12);
        Employee result = employeeRepository.Update(employee);
        Assert.True(CompareEmployee(employee, result));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(6)]
    public void Delete(int id)
    {
        Employee employee = employeeRepository.FindById(id);
        Employee result = employeeRepository.Delete(id);
        Assert.True(CompareEmployee(employee, result));
    }

    private bool CompareEmployee(Employee e1, Employee e2)
    {
        if (e1 == null && e2 == null)
        {
            return true;
        }
        if (e1 == null || e2 == null)
        {
            return false;
        }
        PropertyInfo[] properties = typeof(Employee).GetProperties();
        foreach (var property in properties)
        {
            var val1 = property.GetValue(e1);
            var val2 = property.GetValue(e2);
            if (!Object.Equals(val1, val2))
            {
                return false;
            }
        }
        return true;
    }
}