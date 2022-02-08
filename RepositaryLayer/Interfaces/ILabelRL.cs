﻿namespace RepositaryLayer.Interfaces
{
    using RepositaryLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface ILabelRL
    {
        public LabelEntity Addlabel(long noteid, long userid, string labels);
        public IEnumerable<LabelEntity> GetlabelsByNoteid(long noteid,long userid);
        public bool RemoveLabel(long userID, string labelName);
        public IEnumerable<LabelEntity> RenameLabel(long userID, string oldLabelName, string labelName);
    }
}
