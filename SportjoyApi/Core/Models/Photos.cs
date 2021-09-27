using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Photos
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public int ClubId { get; set; }
    }
}
