using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MusicGroups.Domain;

namespace MusicGroups.DAL.Entities
{
    [Table("Groups")]
    public class GroupEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        
        public string Company { get; set; }
        public string DebutAlbum { get; set; }
        public DateTime DateOfDebut { get; set; }
        
        public ICollection<MemberEntity> Members { get; set; } = new List<MemberEntity>();

        public GroupEntity MapToEntity(Group group)
        {
            this.Id = group.Id;
            this.Title = group.Title;
            this.Company = group.Company;
            this.DebutAlbum = group.DebutAlbum;
            this.DateOfDebut = group.DateOfDebut;
            
            return this;
        }

        public Group MapToModel()
        {
            var group = new Group(this.Title, this.Company, this.DebutAlbum, this.DateOfDebut) { Id = this.Id };
            ((List<Member>)group.Members).AddRange(this.Members.Select(x => x.MapToModel(group)));

            return group;
        }
    }
}