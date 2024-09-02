using Microsoft.AspNetCore.Mvc;
using TSM.Issue.Application;
using TSM.Issue.Domain;

namespace TSM.Issue.Api;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
  private CategoryService _service;
  public CategoryController(CategoryService service)
  {
    _service = service;
  }
  
  [HttpGet]
  public IEnumerable<Category> Get()
  {
    return _service.GetAll();
  }

  [HttpPost]
  public IActionResult Create(Category category)
  {
    _service.Create(category);
    return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
  }
  
  [HttpPut("{id}")]
  public IActionResult Update(int id, Category category)
  {
    if (id != category.Id)
      return BadRequest();
           
    var existingCategory = _service.GetById(id);
    if(existingCategory is null)
      return NotFound();
   
    _service.Update(id, category);           
   
    return NoContent();
  }
  
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var category = _service.GetById(id);
   
    if (category is null)
      return NotFound();
       
    _service.DeleteById(id);
    
    return NoContent();
  }
}