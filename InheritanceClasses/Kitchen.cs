using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceClasses
{
    public class Kitchen : House
    {
        public Kitchen()
        {
            SquareFeet = 500;
            Flooring = FloorType.Wood;
        }
        public int NumberOfAppliances { get; set; }
        public bool HasAnIsland { get; set; }
        public string GoodPartySpace { get; set; }
    }
}
