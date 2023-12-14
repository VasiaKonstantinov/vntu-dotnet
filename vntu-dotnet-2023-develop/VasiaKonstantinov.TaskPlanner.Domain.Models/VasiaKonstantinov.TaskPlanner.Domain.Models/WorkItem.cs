using VasiaKonstantinov.TaskPlanner.Domain.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasiaKonstantinov.TaskPlanner.Domain.Models
{
    public class WorkItem
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool IsCompleted { get; set; }

        public WorkItem()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        public WorkItem(WorkItem original)
        {
            Id = original.Id;
            CreationDate = original.CreationDate;
            DueDate = original.DueDate;
            Priority = original.Priority;
            Complexity = original.Complexity;
            title = original.title;
            description = original.description;
            IsCompleted = original.IsCompleted;
        }

        public WorkItem Clone()
        {
            return new WorkItem(this);
        }

        public override string ToString()
        {
            return $"id: {Id}; title: {title}; IsCompleted: {IsCompleted}; description: {description} due {DueDate:dd.MM.yyyy}, {Priority.ToString().ToLower()} priority";
        }

    }
}
