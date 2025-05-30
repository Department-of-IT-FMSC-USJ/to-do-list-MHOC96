namespace TaskManagementSystem
{
    public class TaskNode
    {
        public Task Task { get; set; }
        public TaskNode Next { get; set; }

        public TaskNode(Task task)
        {
            Task = task;
            Next = null;
        }
    }
}