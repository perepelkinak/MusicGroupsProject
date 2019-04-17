using System;
using System.ComponentModel.DataAnnotations;

namespace MusicGroups.Domain
{
    public class Member
    {
        public Guid Id { get; set; }
        public string StageName { get; set; }
        public string RealName { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        //public byte[] Photo { get; set; }
        public Group Group { get; set; }

        public Member(string stageName, string realName, string city, 
            DateTime dateOfBirth, string position)
        {
            this.StageName = stageName;
            this.RealName = realName;
            
            this.City = city;
            this.DateOfBirth = dateOfBirth;
            this.Position = position;
        }
    }
}