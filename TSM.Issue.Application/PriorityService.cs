using Microsoft.EntityFrameworkCore;
using TSM.Issue.Domain;
using TSM.Issue.Infrastructure;

namespace TSM.Issue.Application;

public class PriorityService
{
  private readonly ProblemContext _context;

  public PriorityService(ProblemContext context)
  {
    _context = context;
  }
  
  public IEnumerable<Priority> GetAll()
  {
    return _context.Priorities
      .AsNoTracking()
      .ToList();
  }
  
  public Priority? GetById(int id)
  {
    return _context.Priorities
      .AsNoTracking()
      .SingleOrDefault(p => p.Id == id);
  }
  
  public Priority Create(Priority newPriority)
  {
    _context.Priorities.Add(newPriority);
    _context.SaveChanges();

    return newPriority;
  }
  
  public void Update(int priorityId, Priority priority)
  {
    var priorityToUpdate = _context.Priorities.Find(priority);

    if (priorityToUpdate is null)
    {
      throw new InvalidOperationException("priority does not exist");
    }

    priorityToUpdate = priority;

    _context.SaveChanges();
  }
  
  public void DeleteById(int id)
  {
    var priorityToDelete = _context.Priorities.Find(id);
    if (priorityToDelete is not null)
    {
      _context.Priorities.Remove(priorityToDelete);
      _context.SaveChanges();
    }
  }
}