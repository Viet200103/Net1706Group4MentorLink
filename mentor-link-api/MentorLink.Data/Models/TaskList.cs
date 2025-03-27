using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

[Table("TaskList")]
public partial class TaskList
{
    [Key] public int TaskListId { get; set; }

    [Required] [MaxLength(255)] public string ListName { get; set; }

    public int Position { get; set; }

    [ForeignKey("TaskBoard")][Required] public int TaskBoardId { get; set; }
    
    public virtual TaskBoard TaskBoard { get; set; }
}