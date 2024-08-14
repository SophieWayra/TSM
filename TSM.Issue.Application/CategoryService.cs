using Microsoft.EntityFrameworkCore;
using TSM.Issue.Domain;
using TSM.Issue.Infrastructure;

namespace TSM.Issue.Application;

public class CategoryService
{
  private readonly ProblemContext _context;

  public CategoryService(ProblemContext context)
  {
    _context = context;
  }
  
  public IEnumerable<Category> GetAll()
  {
    return _context.Categories
      .AsNoTracking()
      .ToList();
  }
  
  public Category? GetById(int id)
  {
    return _context.Categories
      .AsNoTracking()
      .SingleOrDefault(p => p.Id == id);
  }
  
  public Category Create(Category newCategory)
  {
    _context.Categories.Add(newCategory);
    _context.SaveChanges();

    return newCategory;
  }
  
  public void Update(int categoryId, Category category)
  {
    var categoryToUpdate = _context.Categories.Find(category);

    if (categoryToUpdate is null)
    {
      throw new InvalidOperationException("Category does not exist");
    }

    categoryToUpdate = category;

    _context.SaveChanges();
  }
  
  public void DeleteById(int id)
  {
    var categoryToDelete = _context.Categories.Find(id);
    if (categoryToDelete is not null)
    {
      _context.Categories.Remove(categoryToDelete);
      _context.SaveChanges();
    }
  }
}