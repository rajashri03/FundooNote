namespace BusinessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BusinessLayer.Interfaces;
    using RepositaryLayer.Entities;
    using RepositaryLayer.Interfaces;
    public class CollabBL:ICollabBL
    {
        ICollabRL collabRl;//decalring collabrl(repository layer) variable
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collabRl"></param>
        public CollabBL(ICollabRL collabRl)
        {
            this.collabRl = collabRl;
        }
        /// <summary>
        /// Implementation of interface(ICollabBl)
        /// </summary>
        /// <param name="noteid"></param>
        /// <param name="userid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public CollabEntity AddCollab(long noteid, long userid, string email)
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
