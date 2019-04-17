using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicGroups.Domain
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string DebutAlbum { get; set; }
        public DateTime DateOfDebut { get; set; }
        public ICollection<Member> Members { get; set; } = new List<Member>();
        
        public Group(string title, string company, string debutAlbum, DateTime dateOfDebut)
        {
            this.Title = title;
            this.Company = company;
            this.DebutAlbum = debutAlbum;
            this.DateOfDebut = dateOfDebut;
        }
    }
}