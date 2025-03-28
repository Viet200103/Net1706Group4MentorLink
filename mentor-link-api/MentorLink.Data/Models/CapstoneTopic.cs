﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorLink.Data.Models
{
    [Table("CapstoneTopic")]
    public partial class CapstoneTopic
    {
        [Key]
        public int CapstoneTopicId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime SendTime { get; set; }

        public DateTime? ResponseTime { get; set; }

        [MaxLength(100)]
        public string? ResponseBy { get; set; }

        public string? ResponseMessage { get; set; }

        public string Content { get; set; }

        [ForeignKey("CapstoneWorkspace")]
        public int CapstoneWorkspaceId { get; set; }
        public CapstoneWorkspace CapstoneWorkspace { get; set; }
    }
}
