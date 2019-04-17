using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicGroups.Domain;

namespace MusicGroups.DAL.Entities
{
    [Table("Members")]
    public class MemberEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual string StageName { get; set; }
        public virtual string RealName { get; set; }
        
        public virtual string City { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Position { get; set; }
        
        public virtual GroupEntity Group { get; set; }

        public MemberEntity MapToEntity(Member member, GroupEntity group)
        {
            this.Id = member.Id;
            this.StageName = member.StageName;
            this.RealName = member.RealName;
            this.City = member.City;
            this.DateOfBirth = member.DateOfBirth;
            this.Position = member.Position;
            this.Group = group;
            
            return this;
        }

        public Member MapToModel(Group group)
        {
            var member = new Member(this.StageName, this.RealName, this.City, this.DateOfBirth, 
                this.Position) { Id = this.Id };
            member.Group = group;

            return member;
        }
    }
}