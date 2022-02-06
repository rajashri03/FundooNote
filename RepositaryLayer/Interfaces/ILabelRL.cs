using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Model;

namespace RepositaryLayer.Interfaces
{
    public interface ILabelRL
    {
        public bool AddLabel(LabelModel label);
    }
}
