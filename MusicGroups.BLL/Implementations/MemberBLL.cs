using System;
using System.Collections.Generic;
using MusicGroups.BLL.Contracts;
using MusicGroups.DAL;
using MusicGroups.Domain;

namespace MusicGroups.BLL.Implementations
{
    public class MemberBLL : IMemberBLL
    {
        public readonly IRepository _repo;

        public MemberBLL(IRepository repository)
        {
            this._repo = repository;
        }
        
        public Member GetById(Guid id)
        {
            return this._repo.GetMemberById(id);
        }

        public Member AddNew(Member member)
        {
            var addedMember = this._repo.Save(member);
            return addedMember;
        }
        
        public void Edit(Member member)
        {
            var savedMember = this._repo.Save(member);
        }
        
        public void Delete(Guid id)
        {
            this._repo.DeleteMember(id);
        }

        public ICollection<Member> GetMembersByGroup(Group group)
        {
            return this._repo.GetGroupById(group.Id).Members;
        }
    }
}