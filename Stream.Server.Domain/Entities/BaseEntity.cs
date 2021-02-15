using System;
using System.ComponentModel.DataAnnotations;

namespace Stream.Server.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
