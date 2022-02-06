using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositaryLayer.Entities;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class NoteBL:INoteBL
    {
        INoteRL noterl;
        public NoteBL(INoteRL noterl)
        {
            this.noterl = noterl;
        }
        public bool AddNote(NoteModel noteModel,long userid)
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
        public bool UpdateNotes(NoteModel noteModel, long noteid)
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
        public bool IsPinORNot(long noteid)
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
        public bool IsArchiveORNot(long noteid)
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
        public bool IstrashORNot(long noteid)
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
        public bool UploadImage(long noteid,IFormFile img)
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
        public bool Color(long noteid, string color)
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
