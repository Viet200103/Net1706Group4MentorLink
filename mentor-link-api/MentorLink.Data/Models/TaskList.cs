using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

public partial class TaskList
{
    [Key]
    public int TaskListId { get; set; }

    [Required]
    [MaxLength(255)]
    public string ListName { get; set; }

    public int Position { get; set; }

    [ForeignKey("TaskBoard")]
    public int TaskBoardId { get; set; }
    public TaskBoard TaskBoard { get; set; }
}
