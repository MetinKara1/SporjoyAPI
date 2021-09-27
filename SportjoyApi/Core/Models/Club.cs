using Core.Enums;
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
            new List<Comment>();
        }
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Adress { get; set; }
        public string DescribeClub { get; set; }
        public int ManCoachCount { get; set; }
        public int WomenCoachCount { get; set; }
        public DateTime TrainingTime { get; set; }
        public AgeGroupTypes AgeGroups { get; set; }
        public bool isAvailableForDisabled { get; set; }
        public bool havePrivateLesson { get; set; }
        public int Due { get; set; }
        public int tryLessonPrice { get; set; }
        public bool haveParking { get; set; }
        public bool haveShower { get; set; }
        public float SaloonMeters { get; set; }
        public int TrainingCountPerWeek { get; set; }
        public string Videos { get; set; }
        public PeymentTypes PeymentType { get; set; }
        public BranchType BranchType { get; set; }
        public MembershipType MembershipType { get; set; }
        public ICollection<ClubProperties> ClubProterties { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Photos> Photos { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
