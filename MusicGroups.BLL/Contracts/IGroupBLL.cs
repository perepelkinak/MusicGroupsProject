using System;
using System.Collections.Generic;
using MusicGroups.Domain;

namespace MusicGroups.BLL.Contracts
{
    public interface IGroupBLL
    {
        Group GetById(Guid id);
        
        //Создание новой группы
        Group CreateNew(Group group);

        //Редактирование информации о группе 
        void Update(Group group);

        //Удаление группы
        void Delete(Guid id);

        //Может поиск по группе (названию?)

        //Может получение всех групп
        ICollection<Group> GetAll();
    }
}