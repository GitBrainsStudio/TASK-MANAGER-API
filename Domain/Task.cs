using System;

namespace Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public Guid TodoListId { get; set; }

        public Task(
            Guid id,
            string name,
            bool completed,
            Guid todoListId)
        {
            this.Id = id;
            this.Name = name;
            this.Completed = completed;
            this.TodoListId = todoListId;
        }

        /// <summary>
        /// For EF
        /// </summary>
        public Task() { }
    }
}
