using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp2.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }
        public User Receiver { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
