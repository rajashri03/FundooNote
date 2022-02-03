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
    public class NotesController : ControllerBase
    {
        INoteBL noteBL;
        
        public NotesController(INoteBL noteBL)
        {
            this.noteBL = noteBL;

        }
        [HttpPost]
        public IActionResult AddNotes(NoteModel addnote,long userid)
        {
            try
            {
                if (noteBL.AddNote(addnote,userid))
                {
                    return this.Ok(new { Success = true, message = "Note Added Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to add note" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        public IActionResult DeleteNotes(long noteid)
        {
            try
            {
                if (noteBL.DeleteNote(noteid))
                {
                    return this.Ok(new { Success = true, message = "Note Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to delete note" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut]
        public IActionResult updateNotes(NoteModel addnote, long noteid)
        {
            try
            {
                if (noteBL.UpdateNotes(addnote, noteid))
                {
                    return this.Ok(new { Success = true, message = "Note Updated Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to Update note" });
                }
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false, message = "Unable to Update note" });
            }
        }

        [HttpPut]
        public IActionResult Ispinornot(long noteid)
        {
            try
            {
                if (noteBL.IsPinORNot(noteid))
                {
                    return this.Ok(new { message = "Note unPinned " });
                }
                else
                {
                    return this.BadRequest(new { message = "Note Pinned Successfully" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult Istrashornot(long noteid)
        {
            try
            {
                if (noteBL.IsPinORNot(noteid))
                {
                    return this.Ok(new { message = "Note Restored " });
                }
                else
                {
                    return this.BadRequest(new { message = "Note is in trash" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult IsArchiveORNot(long noteid)
        {
            try
            {
                if (noteBL.IsPinORNot(noteid))
                {
                    return this.Ok(new {message = "Note Unarchived " });
                }
                else
                {
                    return this.BadRequest(new {message = "Note Archived Successfully" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult UploadImage(long noteid,IFormFile img)
        {
            try
            {
                if (noteBL.UploadImage(noteid, img))
                {
                    return this.Ok(new { message = "uploaded " });
                }
                else
                {
                    return this.BadRequest(new { message = "Not uploaded" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IEnumerable<NoteEntity> GetAllNotesbyuser(long userid)
        {
            try
            {
                return noteBL.GetAllNotesbyuserid(userid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IEnumerable<NoteEntity> GetAllNote()
        {
            try
            {
                return noteBL.GetAllNotes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        

    }
}
