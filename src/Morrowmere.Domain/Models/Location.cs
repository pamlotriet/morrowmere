using System;
namespace Morrowmere.Domain.Models
{
    public class Location
    {
        // TODO: Convert to GUID later
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsAccessible { get; set; }
    }
}

