using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MusicGroups.BLL.Contracts;
using MusicGroups.DAL;
using MusicGroups.Domain;

namespace MusicGroups.BLL.Implementations
{
    public class GroupBLL : IGroupBLL
    {
        private readonly IRepository _repo;

        public GroupBLL(IRepository repository)
        {
            this._repo = repository;
        }

        public Group GetById(Guid id)
        {
            return this._repo.GetGroupById(id);
        }
        
        public Group CreateNew(Group group)
        {
            return this._repo.Save(group);
        }

        public void Update(Group group)
        {
            this._repo.Save(group);
        }

        public void Delete(Guid id)
        {
            this._repo.DeleteGroup(id);
        }
        
        public ICollection<Group> GetAll()
        {
            return this._repo.GetAllGroups();
        }
    }
}