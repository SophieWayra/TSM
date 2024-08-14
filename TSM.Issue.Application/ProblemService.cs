using Microsoft.EntityFrameworkCore;
using TSM.Issue.Domain;
using TSM.Issue.Infrastructure;

namespace TSM.Issue.Application;

public class ProblemService
{
  private readonly ProblemContext _context;

  public ProblemService(ProblemContext context)
  {
    _context = context;
  }
  public IEnumerable<ProblemListView> GetAll()
  {
    Console.WriteLine(
      _context.Problems
        .Include(p => p.Category )
        .Include(p => p.Priority)
        .ToList());
   
    return _context.Problems
      .Select(p => new ProblemListView
      {
        Category = p.Category.Name,
        Priority = p.Priority.Name,
        Id = p.Id,
        Description = p.Description,
        DueDate = p.DueDate,
        CreationDate = p.CreationDate,
        Name = p.Name
      })
        // .Include(p => p.Category)
        // .Include(p => p.Priority)
        .AsNoTracking()
        .ToList();
  }

  public Problem? GetById(int id)
  {
    return _context.Problems
        .Include(p => p.Category)
        .Include(p => p.Priority)
        .AsNoTracking()
        .SingleOrDefault(p => p.Id == id);
  }

  public Problem Create(ProblemCreate newProblem)
  {
    var category  = _context.Categories.Find(newProblem.CategoryId);
    var priority  = _context.Priorities.Find(newProblem.PriorityId);

    var problem = new Problem
    {
      Category = category,
      Priority = priority,
      Name = newProblem.Name,
      Description = newProblem.Description,
      DueDate = newProblem.DueDate,
      CreationDate = new DateTime(),
    };
    
    _context.Problems.Add(problem);
    _context.SaveChanges();

    return problem;
  }
  
  public void Update(int problemId, Problem problem)
  {
    var problemToUpdate = _context.Problems.Find(problemId);

    if (problemToUpdate is null)
    {
      throw new InvalidOperationException("Problem does not exist");
    }

    problemToUpdate = problem;

    _context.SaveChanges();
  }


  public void DeleteById(int id)
  {
    var problemToDelete = _context.Problems.Find(id);
    if (problemToDelete is not null)
    {
      _context.Problems.Remove(problemToDelete);
      _context.SaveChanges();
    }
  }
}