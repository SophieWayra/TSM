using Microsoft.AspNetCore.Mvc;
using TSM.Issue.Application;
using TSM.Issue.Domain;

namespace TSM.Issue.Api;

[ApiController]
[Route("[controller]")]
public class ProblemController : ControllerBase
{ 
  private ProblemService _service;
  public ProblemController(ProblemService service)
  {
    _service = service;
  }
  
  [HttpGet]
  public IEnumerable<ProblemListView> Get()
  {
    return _service.GetAll();
  }
  
  [HttpGet("{id}")]
  public ActionResult<Problem> GetById(int id)
  {
    var problem = _service.GetById(id);
    if (problem == null)
    {
      return NotFound();
    }
    return problem;
  }

  [HttpPost]
  public IActionResult Create(ProblemCreate problem)
  {
    var newProblem = _service.Create(problem);
    return CreatedAtAction(nameof(Get), new { id = newProblem.Id }, newProblem);
  }
  
  [HttpPut("{id}")]
  public IActionResult Update(int id, Problem problem)
  {
    if (id != problem.Id)
      return BadRequest();
           
    var existingProblem = _service.GetById(id);
    if(existingProblem is null)
      return NotFound();
   
    _service.Update(id, problem);           
   
    return NoContent();
  }
  
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var problem = _service.GetById(id);
   
    if (problem is null)
      return NotFound();
       
    _service.DeleteById(id);
    
    return NoContent();
  }
}