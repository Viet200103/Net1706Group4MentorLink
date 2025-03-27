using MentorLink.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Business.Dtos
{
    public class TaskListDto
    {
        public int TaskListId { get; set; }

        [Required][MaxLength(255)] public string ListName { get; set; }

        [Required]public int Position { get; set; }
        public int TaskBoardId { get; set; }
        public virtual TaskBoard TaskBoard { get; set; }
    }
}
