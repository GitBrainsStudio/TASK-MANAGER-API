using System;
using System.Collections.Generic;

namespace Domain
{
    public class TodoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public TodoList(
            Guid id,
            string name,
            List<Task> tasks)
        {
            this.Id = id;
            this.Name = name;
            this.Tasks = tasks;
        }


        /// <summary>
        /// For EF
        /// </summary>
        public TodoList() { }
    }
}
