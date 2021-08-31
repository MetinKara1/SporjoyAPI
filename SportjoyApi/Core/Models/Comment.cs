using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string  UserComment { get; set; }
        public DateTime CommentDate { get; set; }
        public string Commenter { get; set; }
        public bool IsApproved { get; set; }
        public int ClubId { get; set; }
    }
}
