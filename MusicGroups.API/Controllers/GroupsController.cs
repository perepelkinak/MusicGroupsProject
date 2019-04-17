using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Xml;
using MusicGroups.BLL.Contracts;
using MusicGroups.BLL.Implementations;
using MusicGroups.DAL;
using MusicGroups.Domain;

namespace MusicGroups.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupBLL groupBLL;

        public GroupsController()
        {
            this.groupBLL = new GroupBLL(new Repository());
            
        }

        //GET api/groups
        [HttpGet]
        public ActionResult<ICollection<Group>> Get()
        {
            return new ActionResult<ICollection<Group>>(groupBLL.GetAll());
        }

        //POST api/groups
        [HttpPost]
        public ActionResult<Group> Post([FromBody] Group group)
        {
            var addedGroup = groupBLL.CreateNew(group);
            return addedGroup;
        }

        //DELETE api/groups/id
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            groupBLL.Delete(id);
        }
    }
}