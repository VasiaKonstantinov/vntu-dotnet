using VasiaKonstantinov.TaskPlanner.Domain.Models;
using Newtonsoft.Json;
using System.Xml;

namespace VasiaKonstantinov.TaskPlanner.DataAccess
{
    public class FileWorkItemsRepository
    {
        private const string FileName = "work-items.json";
        private readonly Dictionary<Guid, WorkItem> workItems = new Dictionary<Guid, WorkItem>();

        public FileWorkItemsRepository()
        {
            LoadDataFromFile();
        }

        public Guid Add(WorkItem workItem)
        {
            Guid id = Guid.NewGuid();
            workItem.Id = id;
            workItems[id] = workItem;
            SaveChanges();
            return id;
        }

        public WorkItem Get(Guid id)
        {
            if (workItems.TryGetValue(id, out WorkItem workItem))
            {
                return workItem.Clone();
            }
            return null;
        }

        public List<WorkItem> GetAll()
        {
            return workItems.Values.Select(w => w.Clone()).ToList();
        }

        public bool Update(WorkItem workItem)
        {
            if (workItems.ContainsKey(workItem.Id))
            {
                workItems[workItem.Id] = workItem;
                SaveChanges();
                return true;
            }
            return false;
        }

        public bool Remove(Guid id)
        {
            if (workItems.ContainsKey(id))
            {
                workItems.Remove(id);
                SaveChanges();
                return true;
            }
            return false;
        }

        public void SaveChanges()
        {
            var json = JsonConvert.SerializeObject(workItems.Values.ToArray(), Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FileName, json);
        }

        private void LoadDataFromFile()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                var items = JsonConvert.DeserializeObject<WorkItem[]>(json);
                if (items != null)
                {
                    workItems.Clear();
                    foreach (var item in items)
                    {
                        workItems[item.Id] = item;
                    }
                }
            }
        }
    }
}