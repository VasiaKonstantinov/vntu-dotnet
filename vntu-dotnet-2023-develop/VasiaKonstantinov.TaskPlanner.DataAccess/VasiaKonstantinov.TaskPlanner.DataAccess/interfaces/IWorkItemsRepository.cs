using VasiaKonstantinov.TaskPlanner.Domain.Models;
using System;
using System.Collections.Generic;

public interface IWorkItemsRepository
{
    Guid Add(WorkItem workItem);
    WorkItem Get(Guid id);
    List<WorkItem> GetAll();
    bool Update(WorkItem workItem);
    bool Remove(Guid id);
    void SaveChanges();
}