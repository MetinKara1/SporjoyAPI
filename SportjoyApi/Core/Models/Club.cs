using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Club
    {
        public Club()
        {
            new ClubProperties();
        }
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int Fiyat { get; set; }
        public ClubProperties ClubProterties { get; set; }
    }
}
