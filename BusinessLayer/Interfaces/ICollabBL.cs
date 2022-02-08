namespace BusinessLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RepositaryLayer.Entities;
    public interface ICollabBL
    { 
        /// <summary>
        /// Method to add collaborator
        /// </summary>
        /// <param name="noteid"></param>
        /// <param name="userid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public CollabEntity AddCollab(long noteid, long userid, string email);

        /// <summary>
        /// Method for removing collaborator
        /// </summary>
        /// <param name="collabid"></param>
        /// <returns></returns>
        public bool Remove(long collabid);

        /// <summary>
        /// Method to get all notes by their Id
        /// </summary>
        /// <param name="noteid"></param>
        /// <returns></returns>
        IEnumerable<CollabEntity> GetAllByNoteID(long noteid);
    }
}
