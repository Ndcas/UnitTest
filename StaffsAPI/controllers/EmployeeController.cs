using Microsoft.AspNetCore.Mvc;
using StaffsAPI.models;
using StaffsAPI.repos;

namespace StaffsAPI.controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private IEmployeeRepository employeeRepository;

    public EmployeeController()
    {
        employeeRepository = new EmployeeRepository();
    }

    [HttpGet]
    public ActionResult<List<Employee>> FindAll()
    {
        return Ok(employeeRepository.FindAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Employee> FindById(int id)
    {
        Employee employee = employeeRepository.FindById(id);
        if (employee == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "Not found");
        }
        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> Create([FromForm] Employee employee)
    {
        Employee inserted = employeeRepository.Create(employee);
        if (inserted == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Creation failed");
        }
        return Ok(inserted);
    }

    [HttpPut]
    public ActionResult<Employee> Update([FromForm] Employee employee)
    {
        Employee updated = employeeRepository.Update(employee);
        if (updated == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Update failed");
        }
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Employee> Delete(int id)
    {
        Employee deleted = employeeRepository.Delete(id);
        if (deleted == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Deletion failed");
        }
        return Ok(deleted);
    }
}