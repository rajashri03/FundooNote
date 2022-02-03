using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositaryLayer.Entities;

namespace RepositaryLayer.Interfaces
{
    public interface INoteRL
    {
        public bool AddNote(NoteModel node, long UserId);
        public bool DeleteNote(long noteid);
        public bool UpdateNotes(NoteModel notes, long Noteid);
        IEnumerable<NoteEntity> GetAllNotes();
        IEnumerable<NoteEntity> GetAllNotesbyuserid(long userid);
        public bool IsPinORNot(long noteid);
        public bool IsArchiveORNot(long noteid);
        public bool IstrashORNot(long noteid);
        public bool UploadImage(long noteid, IFormFile img);
    }
}
