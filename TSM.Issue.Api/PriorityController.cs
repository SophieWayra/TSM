using Microsoft.AspNetCore.Mvc;
using TSM.Issue.Application;
using TSM.Issue.Domain;

namespace TSM.Issue.Api;

[ApiController]
[Route("[controller]")]
public class PriorityController : ControllerBase
{
  private PriorityService _service;
  public PriorityController(PriorityService service)
  {
    _service = service;
  }
  
  [HttpGet]
  public IEnumerable<Priority> Get()
  {
    return _service.GetAll();
  }

  [HttpPost]
  public IActionResult Create(Priority priority)
  {
    _service.Create(priority);
    return CreatedAtAction(nameof(Get), new { id = priority.Id }, priority);
  }
  
  [HttpPut("{id}")]
  public IActionResult Update(int id, Priority priority)
  {
    if (id != priority.Id)
      return BadRequest();
           
    var existingPriority = _service.GetById(id);
    if(existingPriority is null)
      return NotFound();
   
    _service.Update(id, priority);           
   
    return NoContent();
  }
  
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var priority = _service.GetById(id);
   
    if (priority is null)
      return NotFound();
       
    _service.DeleteById(id);
    
    return NoContent();
  }
}