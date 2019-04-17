using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Xml;
using MusicGroups.BLL.Contracts;
using MusicGroups.BLL.Implementations;
using MusicGroups.Domain;

namespace MusicGroups.API.Controllers
{
    public class MembersController : ControllerBase
    {
        private readonly IMemberBLL memberBLL;

        public MembersController(IMemberBLL memberBll)
        {
            this.memberBLL = memberBll;
        }
        
        //GET api/members/id
        [HttpGet("{id}")]
        public ActionResult<Member> Get(Guid id)
        {
            return memberBLL.GetById(id);
        }

        //POST api/members
        [HttpPost]
        public ActionResult<Member> Post([FromBody] Member member)
        {
            var createdMember = memberBLL.AddNew(member);
            return createdMember;
        }

        // PUT api/members/id
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Member member)
        {
            member.Id = id;
            memberBLL.Edit(member);
        }

        // DELETE api/members/id
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            memberBLL.Delete(id);
        }
    }
}