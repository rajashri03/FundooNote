using System;
using System.Collections.Generic;
using System.Text;
using RepositaryLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ICollabBL
    {
        public bool AddCollab(long noteid, long userid, string email);
        public bool Remove(long collabid);
        IEnumerable<CollabEntity> GetAllByNoteID(long noteid);
    }
}
