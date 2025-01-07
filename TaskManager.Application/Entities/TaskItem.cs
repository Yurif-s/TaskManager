using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Communication.Enums;

namespace TaskManager.Application.Entities;

[Table("Tasks")]
public class TaskItem
{
    [Required]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(80)]
    public string? Name { get; set; }

    [StringLength(80)]
    public string? Description { get; set; }

    [Required]
    public PriorityType Priority { get; set; }

    [Required]
    public DateTime LimitDate { get; set; }
    public StatusType Status { get; set; } = StatusType.Waiting;
}
