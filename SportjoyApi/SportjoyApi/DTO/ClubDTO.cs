﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTO
{
    public class ClubDTO
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Adress { get; set; }
        public string DescribeClub { get; set; }
        public int ManCoachCount { get; set; }
        public int WomenCoachCount { get; set; }
        public DateTime TrainingTime { get; set; }
        public string AgeGroups { get; set; }
        public bool isAvailableForDisabled { get; set; }
        public bool havePrivateLesson { get; set; }
        public int Due { get; set; }
        public int tryLessonPrice { get; set; }
        public bool haveParking { get; set; }
        public bool haveShower { get; set; }
        public float SaloonMeters { get; set; }
        public int TrainingCountPerWeek { get; set; }
        public string Photos { get; set; }
        public string Videos { get; set; }
        public string PeymentType { get; set; }
    }
}
