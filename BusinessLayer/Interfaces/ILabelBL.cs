namespace BusinessLayer.Interfaces
{
    using RepositaryLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface ILabelBL
    {
        /// <summary>
        /// interface Method to add labels
        /// </summary>
        /// <param name="noteid"></param>
        /// <param name="userid"></param>
        /// <param name="labels"></param>
        /// <returns></returns>
        public LabelEntity Addlabel(long noteid, long userid, string labels);
        /// <summary>
        /// Interface(IEnumrable) method to get labels by note id
        /// </summary>
        /// <param name="noteid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<LabelEntity> GetlabelsByNoteid(long noteid, long userid);
        /// <summary>
        /// Interface method to Remove label
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public bool RemoveLabel(long userID, string labelName);
        /// <summary>
        /// Interface method to Rename labels
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="oldLabelName"></param>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public IEnumerable<LabelEntity> RenameLabel(long userID, string oldLabelName, string labelName);
    }
}
