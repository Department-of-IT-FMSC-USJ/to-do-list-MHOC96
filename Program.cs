using System;

namespace TaskManagementSystem
{
    public class Program
    {
        private static TaskManager taskManager = new TaskManager();
        private static int nextTaskId = 1;

        public static void Main()
        {
            Console.WriteLine("=== TASK MANAGEMENT SYSTEM ===");

            while (true)
            {
                DisplayMenu();

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewTask();
                        break;
                    case "2":
                        MoveTaskToInProgress();
                        break;
                    case "3":
                        CompleteTask();
                        break;
                    case "4":
                        taskManager.DisplayToDoTasks();
                        break;
                    case "5":
                        taskManager.DisplayInProgressTasks();
                        break;
                    case "6":
                        taskManager.DisplayCompletedTasks();
                        break;
                    case "7":
                        DisplayAllTasks();
                        break;
                    case "8":
                        Console.WriteLine("Thank you for using Task Management System!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n======== MENU ========");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. Move Task to In-Progress");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Display To-Do Tasks");
            Console.WriteLine("5. Display In-Progress Tasks");
            Console.WriteLine("6. Display Completed Tasks");
            Console.WriteLine("7. Display All Tasks");
            Console.WriteLine("8. Exit");
            Console.WriteLine("=====================");
        }

        private static void AddNewTask()
        {
            Console.WriteLine("\n=== ADD NEW TASK ===");

            Console.Write("Enter task name: ");
            string taskName = Console.ReadLine();

            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            DateTime date;
            while (true)
            {
                Console.Write("Enter task date (YYYY-MM-DD): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format! Please use YYYY-MM-DD format.");
                }
            }

            Task newTask = new Task(nextTaskId++, taskName, description, date);
            taskManager.InsertToDoTask(newTask);

            Console.WriteLine($"Task '{taskName}' added successfully with ID: {newTask.ID}");
        }

        private static void MoveTaskToInProgress()
        {
            Console.WriteLine("\n=== MOVE TASK TO IN-PROGRESS ===");
            taskManager.DisplayToDoTasks();

            if (taskManager.HasToDoTasks())
            {
                Console.Write("\nEnter the ID of the task to move to In-Progress: ");
                if (int.TryParse(Console.ReadLine(), out int taskId))
                {
                    if (!taskManager.MoveToInProgress(taskId))
                    {
                        Console.WriteLine("Failed to move task. Please check the task ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid task ID.");
                }
            }
            else
            {
                Console.WriteLine("No To-Do tasks available.");
            }
        }

        private static void CompleteTask()
        {
            Console.WriteLine("\n=== COMPLETE TASK ===");
            taskManager.DisplayInProgressTasks();

            if (taskManager.HasInProgressTasks())
            {
                Console.Write("\nDo you want to complete the most recent In-Progress task? (y/n): ");
                string confirm = Console.ReadLine().ToLower();

                if (confirm == "y" || confirm == "yes")
                {
                    if (!taskManager.CompleteTask())
                    {
                        Console.WriteLine("No tasks available to complete.");
                    }
                }
                else
                {
                    Console.WriteLine("Task completion cancelled.");
                }
            }
            else
            {
                Console.WriteLine("No In-Progress tasks available.");
            }
        }

        private static void DisplayAllTasks()
        {
            Console.WriteLine("\n=== ALL TASKS ===");
            taskManager.DisplayToDoTasks();
            taskManager.DisplayInProgressTasks();
            taskManager.DisplayCompletedTasks();
        }
    }
}