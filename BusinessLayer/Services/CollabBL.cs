using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;
using RepositaryLayer.Entities;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class CollabBL:ICollabBL
    {
        ICollabRL collabRl;
        public CollabBL(ICollabRL collabRl)
        {
            this.collabRl = collabRl;
        }

        public bool AddCollab(long noteid, long userid, string email)
        {
            try
            {
                return this.collabRl.AddCollab(noteid, userid,email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Remove(long collabid)
        {
            try
            {
                return this.collabRl.Remove(collabid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<CollabEntity> GetAllByNoteID(long noteid)
        {
            try
            {
                return this.collabRl.GetAllByNoteID(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
