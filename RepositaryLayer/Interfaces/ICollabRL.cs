using System;
using System.Collections.Generic;
using System.Text;
using RepositaryLayer.Entities;

namespace RepositaryLayer.Interfaces
{
    public interface ICollabRL
    {
        public bool AddCollab(long noteid, long userid, string email);
        public bool Remove(long collabid);
        IEnumerable<CollabEntity> GetAllByNoteID(long noteid);
    }
}
