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
            StartingDate = new DateTime(2015, 02, 12)
        });
    }

    [Fact]
    public void FindAll()
    {
        Assert.Equal(4, employeeRepository.FindAll().Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void FindById(int id)
    {
        Employee expected = id <= defaultEmployees.Count ? defaultEmployees[id - 1] : null;
        Assert.True(compareEmployee(expected, employeeRepository.FindById(id)));
    }

    [Theory]
    public void Create(string firstName, string lastName, string email, int yyyy, int mm, int dd, int gender, int department)
    {
    }

    private bool compareEmployee(Employee e1, Employee e2)
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