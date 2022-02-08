﻿namespace BusinessLayer.Services
{
    using BusinessLayer.Interfaces;
    using RepositaryLayer.Entities;
    using RepositaryLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class LabelBL : ILabelBL
    {
        ILabelRL labelbl;
        public LabelBL(ILabelRL labelbl)
        {
            this.labelbl = labelbl;
        }
        public LabelEntity Addlabel(long noteid, long userid, string labels)
        {
            try
            {
                return this.labelbl.Addlabel(noteid, userid, labels);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<LabelEntity> GetlabelsByNoteid(long noteid, long userid)
        {
            try
            {
                return this.labelbl.GetlabelsByNoteid(noteid,userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RemoveLabel(long userID, string labelName)
        {
            try
            {
                return this.labelbl.RemoveLabel(userID, labelName);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IEnumerable<LabelEntity> RenameLabel(long userID, string oldLabelName, string labelName)
        {
            try
            {
                return this.labelbl.RenameLabel(userID, oldLabelName,labelName);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
