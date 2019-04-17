using MusicGroups.BLL.Contracts;
using MusicGroups.BLL.Implementations;
using MusicGroups.DAL;
using Ninject.Modules;

namespace MusicGroups.BLL
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMemberBLL>().To<MemberBLL>();
            this.Bind<IGroupBLL>().To<GroupBLL>();
            this.Bind<IRepository>().To<Repository>();
        }
    }
}