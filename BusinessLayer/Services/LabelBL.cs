using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;
using CommonLayer.Model;

namespace BusinessLayer.Services
{
    public class LabelBL: ILabelBL
    {
        ILabelBL labelRl;
        public LabelBL(ILabelBL labelRl)
        {
            this.labelRl = labelRl;
        }

        public bool AddLabel(LabelModel label)
        {
            try
            {
                return this.labelRl.AddLabel(label);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
