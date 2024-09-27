﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionId { get; set; }

        [Required]
        [StringLength(30)]
        public string? Username { get; set; }

        public string? Email { get; set; }

        [Required]
        public string CookieString { get; set; }

        [Required]
        public DateTimeOffset? ExpireTime { get; set; }
    }
}
