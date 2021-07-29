using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class StaffTrainer
    {
        public int Id { get; set; }
        public string TrainerName { get; set; }
        public string TrainerSurname { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int Price { get; set; }
    }
}
