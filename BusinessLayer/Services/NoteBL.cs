namespace BusinessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BusinessLayer.Interfaces;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using RepositaryLayer.Entities;
    using RepositaryLayer.Interfaces;
    public class NoteBL:INoteBL
    {
        INoteRL noterl;
        public NoteBL(INoteRL noterl)
        {
            this.noterl = noterl;
        }
        /// <summary>
        /// Method to add notes
        /// </summary>
        /// <param name="noteModel"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public NoteEntity AddNote(NoteModel noteModel,long userid)
        {
            try
            {
                return this.noterl.AddNote(noteModel, userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method to delete notes
        /// </summary>
        /// <param name="noteid"></param>
        /// <returns></returns>
        public bool DeleteNote(long noteid)
        {
            try
            {
                return this.noterl.DeleteNote(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method to update notes
        /// </summary>
        /// <param name="noteModel"></param>
        /// <param name="noteid"></param>
        /// <returns></returns>
        public NoteEntity UpdateNotes(NoteModel noteModel, long noteid)
        {
            try
            {
                return this.noterl.UpdateNotes(noteModel,noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method to get all notes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NoteEntity> GetAllNotes()
        {
            try
            {
                return this.noterl.GetAllNotes();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<NoteEntity> GetAllNotesbyuserid(long userid)
        {
            try
            {
                return this.noterl.GetAllNotesbyuserid(userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NoteEntity IsPinORNot(long noteid)
        {
            try
            {
                return this.noterl.IsPinORNot(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NoteEntity IsArchiveORNot(long noteid)
        {
            try
            {
                return this.noterl.IsArchiveORNot(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NoteEntity IstrashORNot(long noteid)
        {
            try
            {
                return this.noterl.IstrashORNot(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NoteEntity UploadImage(long noteid,IFormFile img)
        {
            try
            {
                return this.noterl.UploadImage(noteid,img);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NoteEntity Color(long noteid, string color)
        {
            try
            {
                return this.noterl.Color(noteid, color);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
