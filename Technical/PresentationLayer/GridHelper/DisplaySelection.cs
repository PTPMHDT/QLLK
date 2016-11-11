using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer
{
    class DisplaySelectionAttribute : Attribute
    {
        public string Caption;
        public DisplaySelectionAttribute(string dis)
        {
            Caption = dis;
        }
    }
}
