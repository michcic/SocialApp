using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp2.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public string UserSenderId { get; set; }
        public string UserReceiverId { get; set; }
    }
}
