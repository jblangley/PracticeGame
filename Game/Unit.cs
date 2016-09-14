using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Unit
    {
        public string Name { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int MaxDefense { get; set; }
        public int Magic { get; set; }
        public int MaxMagic { get; set; }
        public string Weakness { get; set; }
        public int Item { get; set; }

        public Unit() { }
    }
}
