using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Model;

namespace BusinessLayer.Interfaces
{
    public interface ILabelBL
    {
        public bool AddLabel(LabelModel label);
    }
}
