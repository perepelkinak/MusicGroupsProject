using System;
using System.Collections.Generic;
using MusicGroups.Domain;

namespace MusicGroups.DAL
{
    public interface IRepository
    {
        Member GetMemberById(Guid id);

        Member Save(Member member);//Сохраняю, типо добавляю в группу мембера

        ICollection<Member> Save(params Member[] members); //Хз, что это. Сохранить всех мемберов?
        
        void DeleteMember(Guid id);

        //Зеркалочка с группами 
        
        Group GetGroupById(Guid id);

        Group Save(Group group);//Сохраняю, типо добавляю новую группу

        ICollection<Group> Save(params Group[] groups); 
        
        void DeleteGroup(Guid id);

        ICollection<Group> GetAllGroups();
    }
}