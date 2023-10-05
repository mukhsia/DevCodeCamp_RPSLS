﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string playerName) : base(playerName) 
        { 

        }

        // Step 4 & 5: Ask a gesture a player will play
        public override void ChooseGesture()
        {
            string gestureInput = "";

            do
            {
                Console.WriteLine("Gestures:");
                
                foreach(string gesture in gestures)
                {
                    Console.WriteLine(gesture);
                }


                Console.Write($"{name}, please choose a gesture to play: ");
                gestureInput = Console.ReadLine();

                if (gestureInput == null || !gestures.Contains(gestureInput))
                {
                    Console.WriteLine("\nPlease enter a valid gesture.");
                }
            } while(gestureInput == null || !gestures.Contains(gestureInput));

            chosenGesture = gestureInput;
        }
    }
}