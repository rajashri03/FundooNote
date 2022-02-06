using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommonLayer;
using CommonLayer.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using RepositaryLayer.AppContext;
using RepositaryLayer.Entities;
using RepositaryLayer.Interfaces;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace RepositaryLayer.Services
{
    public class NoteRL:INoteRL
    {
        private readonly Context context;
        private readonly IConfiguration Iconfiguration;
        public const string CLOUD_NAME = "imageupl";
        public const string API_KEY = "913737481261618";
        public const string API_Secret = "aedXJOOgdxKLFdmWGx8p6_RT6vQ";
        public static Cloudinary cloud;

        public NoteRL(Context context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }
        public bool AddNote(NoteModel notes,long userid)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                noteEntity.Title = notes.Title;
                noteEntity.Note = notes.Note;
                noteEntity.Color = notes.Color;
                noteEntity.Image = notes.Image;
                noteEntity.IsArchive = notes.IsArchive;
                noteEntity.IsPin = notes.IsPin;
                noteEntity.IsTrash = notes.IsTrash;
                noteEntity.userid = userid;
                this.context.Notes.Add(noteEntity);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;

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
                var result = this.context.Notes.FirstOrDefault(x => x.NoteID == noteid);
                context.Remove(result);
                int deletednote = this.context.SaveChanges();
                if (deletednote > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateNotes(NoteModel notes,long noteid)
        {
            try
            {
                var result = context.Notes.Where(e => e.NoteID == noteid).FirstOrDefault();
                if (result != null)
                {
                    //NoteEntity noteEntity = new NoteEntity();
                    result.Title = notes.Title;
                    result.Note = notes.Note;
                    result.Color = notes.Color;
                    result.Image = notes.Image;
                    result.IsArchive = notes.IsArchive;
                    result.IsPin = notes.IsPin;
                    result.IsTrash = notes.IsTrash;
                    context.Notes.Update(result);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<NoteEntity> GetAllNotes()
        {
            return context.Notes.ToList();
        }
        public IEnumerable<NoteEntity> GetAllNotesbyuserid(long userid)
        {
            return context.Notes.Where(n => n.userid == userid).ToList();
        }
        public bool IsPinORNot(long noteid)
        {
            try
            {
                var result = this.context.Notes.FirstOrDefault(x => x.NoteID == noteid);
                if(result.IsPin==true)
                {
                    result.IsPin = false;
                    this.context.SaveChanges();
                    return true;
                }
                result.IsPin = true;
                this.context.SaveChanges();
                return false;
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
                var result = this.context.Notes.FirstOrDefault(x => x.NoteID == noteid);
                if (result.IsArchive == true)
                {
                    result.IsArchive = false;
                    this.context.SaveChanges();
                    return true;
                }
                result.IsArchive = true;
                this.context.SaveChanges();
                return false;
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
                var result = this.context.Notes.FirstOrDefault(x => x.NoteID == noteid);
                if (result.IsTrash == true)
                {
                    result.IsTrash = false;
                    this.context.SaveChanges();
                    return true;
                }
                result.IsTrash = true;
                this.context.SaveChanges();
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UploadImage(long noteid, IFormFile img)
        {
            try
            {
                var noteId = this.context.Notes.FirstOrDefault(e => e.NoteID == noteid);
                if (noteId != null)
                {
                    Account acc = new Account(CLOUD_NAME, API_KEY, API_Secret);
                    cloud = new Cloudinary(acc);
                    var imagePath = img.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(img.FileName, imagePath)
                    };
                    var uploadresult = cloud.Upload(uploadParams);
                    noteId.Image = img.FileName;
                    context.Notes.Update(noteId);
                    int upload = context.SaveChanges();
                    if (upload > 0)
                    {
                        return true;
                    }
                }
                return false;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Color(long noteid,string color)
        {
            try
            {
                NoteEntity note = this.context.Notes.FirstOrDefault(x => x.NoteID == noteid);
                if (note.Color != null)
                {
                    note.Color = color;
                    this.context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
