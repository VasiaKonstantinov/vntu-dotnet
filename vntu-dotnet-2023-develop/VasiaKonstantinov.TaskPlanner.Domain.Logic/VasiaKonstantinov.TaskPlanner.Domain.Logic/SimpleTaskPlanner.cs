using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasiaKonstantinov.TaskPlanner.Domain.Models;

namespace VasiaKonstantinov.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        private readonly IWorkItemsRepository _workItemsRepository;

        public SimpleTaskPlanner(IWorkItemsRepository workItemsRepository)
        {
            _workItemsRepository = workItemsRepository;
        }

        public WorkItem[] CreatePlan()
        {
            var items = _workItemsRepository.GetAll();
            var itemsAsList = items.ToList();
            itemsAsList.Sort(CompareWorkItems);
            return itemsAsList.ToArray();
        }

        public WorkItem[] CreatePlanOld(WorkItem[] items)
        {
            var itemsAsList = items.ToList();
            itemsAsList.Sort(CompareWorkItems);
            return itemsAsList.ToArray();
        }

        private static int CompareWorkItems(WorkItem firstItem, WorkItem secondItem)
        {
            // Comparison logic here
            // Sort by Priority (descending), then by DueDate (ascending), then by Title (alphabetical)
            int priorityComparison = firstItem.Priority.CompareTo(secondItem.Priority);
            if (priorityComparison != 0)
                return -priorityComparison; // Descending order for Priority
            int dueDateComparison = firstItem.DueDate.CompareTo(secondItem.DueDate);
            if (dueDateComparison != 0)
                return dueDateComparison; // Ascending order for DueDate
            return string.Compare(firstItem.title, secondItem.title, StringComparison.Ordinal);
        }
    }
}
