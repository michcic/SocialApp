using SocialApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp2.Models
{
    public class PostCommentView
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
