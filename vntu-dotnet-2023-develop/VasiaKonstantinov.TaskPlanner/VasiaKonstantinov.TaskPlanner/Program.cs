using System;
using System.Collections.Generic;
using VasiaKonstantinov.TaskPlanner.Domain.Logic;
using VasiaKonstantinov.TaskPlanner.Domain.Models;
using VasiaKonstantinov.TaskPlanner.Domain.Models.enums;

class Program
{
    static List<WorkItem> workItems = new List<WorkItem>();

    static void Main()
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[A]dd work item");
            Console.WriteLine("[B]uild a plan");
            Console.WriteLine("[M]ark work item as completed");
            Console.WriteLine("[R]emove a work item");
            Console.WriteLine("[Q]uit the app");

            string userInput = Console.ReadLine()?.ToUpper();

            switch (userInput)
            {
                case "A":
                    AddWorkItem();
                    break;
                case "B":
                    BuildPlan();
                    break;
                case "M":
                    MarkWorkItemAsCompleted();
                    break;
                case "R":
                    RemoveWorkItem();
                    break;
                case "Q":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddWorkItem()
    {
        Console.WriteLine("Enter the title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the due date (yyyy-MM-dd):");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            WorkItem workItem = new WorkItem
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                DueDate = dueDate,
                Priority = Priority.Medium, // You can set the priority as needed.
                Complexity = Complexity.Minutes, // You can set the complexity as needed.
                title = title,
                description = description,
                IsCompleted = false
            };

            workItems.Add(workItem);
            Console.WriteLine("Work item added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }

    static void BuildPlan()
    {
        Console.WriteLine("Work Plan:");
        foreach (var workItem in workItems)
        {
            Console.WriteLine(workItem.ToString());
        }
    }

    static void MarkWorkItemAsCompleted()
    {
        Console.WriteLine("Enter the ID of the work item to mark as completed:");
        if (Guid.TryParse(Console.ReadLine(), out Guid workItemId))
        {
            WorkItem workItem = workItems.Find(item => item.Id == workItemId);
            if (workItem != null)
            {
                workItem.IsCompleted = true;
                Console.WriteLine("Work item marked as completed.");
            }
            else
            {
                Console.WriteLine("Work item not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    static void RemoveWorkItem()
    {
        Console.WriteLine("Enter the ID of the work item to remove:");
        if (Guid.TryParse(Console.ReadLine(), out Guid workItemId))
        {
            WorkItem workItem = workItems.Find(item => item.Id == workItemId);
            if (workItem != null)
            {
                workItems.Remove(workItem);
                Console.WriteLine("Work item removed.");
            }
            else
            {
                Console.WriteLine("Work item not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}