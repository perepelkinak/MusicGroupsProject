using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusicGroups.DAL.Entities;
using MusicGroups.Domain;

namespace MusicGroups.DAL
{
    public class Repository : IRepository
    {
        public Member GetMemberById(Guid id)
        {
            using (var context = new MusicGroupsContext())
            {
                return this.GetMemberById(id, context);
            }
        }
        
        public Member Save(Member member) //Добавить/Сохранить изменения
        {
            using (var context = new MusicGroupsContext())
            {
                var result = this.SaveMember(member, context);

                context.SaveChanges();

                return result;
            }
        }

        public ICollection<Member> Save(params Member[] members)
        {
            using (var context = new MusicGroupsContext())
            {
                var result = this.SaveMembers(members, context);

                context.SaveChanges();

                return result;
            }
       }
        
        public void DeleteMember(Guid id)
        {
            using (var context = new MusicGroupsContext())
            {
                this.DeleteMemberById(id, context);
                
                context.SaveChanges();
            }
        }
        
        public Group GetGroupById(Guid id)
        {
            using (var context = new MusicGroupsContext())
            {
                return this.GetGroupById(id, context);
            }
        }

        public Group Save(Group group)
        {
            using (var context = new MusicGroupsContext())
            {
                var result = this.SaveGroup(group, context);

                context.SaveChanges();

                return result;
            }
        }

        public ICollection<Group> Save(params Group[] groups)
        {
            using (var context = new MusicGroupsContext())
            {
                var result = this.SaveGroups(groups, context);

                context.SaveChanges();

                return result;
            }
        }
        
        public void DeleteGroup(Guid id)
        {
            using (var context = new MusicGroupsContext())
            {
                this.DeleteGroupById(id, context);
                
                context.SaveChanges();
            }
        }


        public ICollection<Group> GetAllGroups()
        {
            using (var context = new MusicGroupsContext())
            {
                return context.Groups.Include(nameof(Group.Members)).ToArray().Select(x => x.MapToModel()).ToArray();
            }
        }

        //---Вспомогательные методы---
        private ICollection<Group> SaveGroups(ICollection<Group> groups, MusicGroupsContext context)
        {
            var result = new List<Group>();

            foreach (var group in groups)
                result.Add(this.SaveGroup(group,context));

            return result;
        }
        
        private Member GetMemberById(Guid id, MusicGroupsContext context)
        {
            var result = context.Members.FirstOrDefault(x => x.Id == id); //получаю entity
            
            if(result == null)
                throw new ArgumentOutOfRangeException(nameof(id));

            return result.MapToModel(result.Group.MapToModel());
        }

        private ICollection<Member> SaveMembers(ICollection<Member> members, MusicGroupsContext context)
        {
            var result = new List<Member>();

            foreach (var member in members)
                result.Add(this.SaveMember(member,context));

            return result;
        }

        private Member SaveMember(Member member, MusicGroupsContext context) //Добавляю нового мембера или обновляю информацию о текущем
        {
            MemberEntity changingMember;

            var group = this.GetGroupByIdEntity(member.Group.Id, context);
            if (member.Id != Guid.Empty)
            {
                changingMember = context.Members.First(x => x.Id == member.Id).MapToEntity(member, group);
            }
            else
            {
                changingMember = new MemberEntity().MapToEntity(member,group);
                changingMember.Id = Guid.NewGuid();
                context.Members.Add(changingMember);
            }
            
            return changingMember.MapToModel(group.MapToModel());
        }

        private Group GetGroupById(Guid id, MusicGroupsContext context)
        {
            var result = this.GetGroupByIdEntity(id, context);
            
            if(result == null)
                throw new ArgumentOutOfRangeException(nameof(id));

            return result.MapToModel();
        }

        private GroupEntity GetGroupByIdEntity(Guid id, MusicGroupsContext context)
        {
            return context.Groups.Include(nameof(Group.Members)).FirstOrDefault(x => x.Id == id);
        }

        private Group SaveGroup(Group group, MusicGroupsContext context)
        {
            GroupEntity changingGroup;
            
            if (group.Id != Guid.Empty)
            {
                changingGroup = context.Groups.First(x => x.Id == group.Id).MapToEntity(group);
            }
            else
            {
                changingGroup = new GroupEntity().MapToEntity(group);
                changingGroup.Id = Guid.NewGuid();
                context.Groups.Add(changingGroup);
            }
            
            return changingGroup.MapToModel();
        }

        private void DeleteMemberById(Guid id, MusicGroupsContext context)
        {
            MemberEntity member = context.Members.FirstOrDefault(x => x.Id == id);
            
            if(member == null)
                throw new ArgumentOutOfRangeException(nameof(id));
            else
                context.Members.Remove(member);
        }

        private void DeleteGroupById(Guid id, MusicGroupsContext context)
        {
            var group = this.GetGroupByIdEntity(id, context);

            foreach (var member in group.Members)
                DeleteMemberById(member.Id,context);
        }
    }
}