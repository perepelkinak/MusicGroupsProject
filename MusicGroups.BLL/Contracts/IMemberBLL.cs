using System;
using System.Collections.Generic;
using System.Globalization;
using MusicGroups.Domain;

namespace MusicGroups.BLL.Contracts
{
    public interface IMemberBLL
    {
        Member GetById(Guid id);
        
        //Добавление нового участника
        Member AddNew(Member member);

        //Редактирование информации об участнике 
        void Edit(Member member);

        //Удаление участника 
        void Delete(Guid id);

        //Может поиск по критериям

        //Получение всех участников группы
        ICollection<Member> GetMembersByGroup(Group group);

        //Загрузить фотографию, если добавлю метод
    }
}