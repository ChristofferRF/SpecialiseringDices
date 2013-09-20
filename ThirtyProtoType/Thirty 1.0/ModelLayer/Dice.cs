using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Dice
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }

        //Constructor for Dice
        public Dice()
        {
            this.Number = 0;
            this.IsActive = true;
        }

        public Dice(int id)
        {
            this.Number = 0;
            this.Id = id;
            this.IsActive = true;
        }
    }
}
