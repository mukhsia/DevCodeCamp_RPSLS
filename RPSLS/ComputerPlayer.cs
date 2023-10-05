using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    internal class ComputerPlayer : Player
    {
        public ComputerPlayer(string playerName) : base("Computer")
        {

        }

        public override void ChooseGesture()
        {
            Random randomNumberGen = new Random();
            chosenGesture = gestures[randomNumberGen.Next() % 5];
        }
    }
}
