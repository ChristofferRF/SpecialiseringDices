using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Dices
    {
        public List<Dice> DiceList { get; set; }
        private static Dices instance;

        private Dices()
        {
            DiceList = new List<Dice>();
        }

        public static Dices GetInstance()
        {
            if(instance == null) {
                instance = new Dices();
            }
            return instance;
        }

        public void AddDice(Dice dice)
        {
            DiceList.Add(dice);
        }

        public Dice GetDice(int diceId)
        {
            int index = 0;
            bool found = false;
            Dice d = null;

            while (index < DiceList.Count() && !found)
            {
                d = DiceList[index];
                if (d.Id == diceId)
                {
                    found = true;
                }
                else
                {
                    index++;
                }
            }
            return d;
        }

        public void AddSixDices()
        {
            //always add six dices to the game
            for (int i = 1; i <= 6; i++)
            {
                DiceList.Add(new Dice(i));
            }
        }
    }
}
