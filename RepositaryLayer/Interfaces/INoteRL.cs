namespace RepositaryLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using RepositaryLayer.Entities;
    public interface INoteRL
    {
        public NoteEntity AddNote(NoteModel node, long UserId);
        public bool DeleteNote(long noteid);
        public NoteEntity UpdateNotes(NoteModel notes, long Noteid);
        IEnumerable<NoteEntity> GetAllNotes();
        IEnumerable<NoteEntity> GetAllNotesbyuserid(long userid);
        public NoteEntity IsPinORNot(long noteid);
        public NoteEntity IsArchiveORNot(long noteid);
        public NoteEntity IstrashORNot(long noteid);
        public NoteEntity UploadImage(long noteid, IFormFile img);
        public NoteEntity Color(long noteid, string color);
    }
}
