using System;

namespace Bryan.BancoBari.Domain.Models
{
    public class HelloWorld
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public HelloWorld(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
