using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp2.Models
{
    public class Invitation
    {
        public int Id { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }
    }
}
