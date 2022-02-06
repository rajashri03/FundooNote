using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositaryLayer.Entities;

namespace Fundoo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        ICollabBL collab;

        public CollabController(ICollabBL collab)
        {
            this.collab = collab;
        }
        //[Authorize]
        [HttpPost]
        public IActionResult AddCollab(long noteid, long userid, string email)
        {
            try
            {
                if (collab.AddCollab(noteid, userid, email))
                {
                    return this.Ok(new { Success = true, message = "Collaborator Added Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to add" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        public IActionResult Remove(long collabid)
        {
            try
            {
                if (collab.Remove(collabid))
                {
                    return this.Ok(new { Success = true, message = "Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to Delete" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public IEnumerable<CollabEntity> GetAllByNoteID(long noteid)
        {
            try
            {
                return collab.GetAllByNoteID(noteid);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
