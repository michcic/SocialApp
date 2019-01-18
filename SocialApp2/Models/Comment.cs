using SocialApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp2.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Content")]
        [MaxLength(5000)]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
