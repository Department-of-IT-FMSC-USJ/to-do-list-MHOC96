using System;

namespace TaskManagementSystem
{
    public class Task
    {
        public string TaskName { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public Task(int id, string taskName, string description, DateTime date)
        {
            ID = id;
            TaskName = taskName;
            Description = description;
            Date = date;
            Status = "To Do";
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {TaskName}, Description: {Description}, Date: {Date:yyyy-MM-dd}, Status: {Status}";
        }
    }
}
