using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    internal class Game
    {
        //Member Variabes (HAS A)
        public Player playerOne;
        public Player playerTwo;

        //Constructor
        public Game()
        {

        }

        //Member Methods (CAN DO)
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to RPSLS! Here are the rules:\n");

            // Step 1: Display the rules of the game 
            Console.WriteLine("Rock crushes Scissors\n" +
                "Scissors cuts Paper\n" +
                "Paper covers Rock\n" +
                "Rock crushes Lizard\n" +
                "Lizard poisons Spock\n" +
                "Spock smashes Scissors\n" +
                "Scissors decapitates Lizard\n" +
                "Lizard eats Paper\n" +
                "Paper disproves Spock\n" +
                "Spock vaporizes Rock\n");
        }

        public int ChooseNumberOfHumanPlayers()
        {
            int playerNum = 0;
            // Step 2: Ask how many human players will be playing
            while (playerNum != 1 && playerNum != 2)
            {
                Console.Write("Enter the number of players (1-2): ");
                playerNum = Convert.ToInt32(Console.ReadLine());

                if (playerNum != 1 && playerNum != 2)
                {
                    // Step 3c: If less than 1 or more than 2
                    //              Step 3c-1: Display "Must choose 1 or 2 players"
                    //              Step 3c-2: go back to step 2
                    Console.WriteLine("Please enter the number '1' for one player or '2' for 2 players, without the quotation marks.\n");
                }
            }
            return playerNum;
        }

        public void CreatePlayerObjects(int numberOfHumanPlayers)
        {
            string nameInput = "";
            bool nameEmpty = true;

            while (nameEmpty)
            {
                // Step 3a-1: Ask for first player name
                Console.Write("Player 1, please enter your name: ");
                nameInput = Console.ReadLine();


                if (String.IsNullOrEmpty(nameInput))
                {
                    Console.WriteLine("\nPlease enter a name.");
                }
                else
                {
                    nameEmpty = false;
                }
            }

            // Instantiate player 1 as a human player
            playerOne = new HumanPlayer(nameInput);

            // Step 3a: If 1 player is playing
            if (numberOfHumanPlayers == 1)
            {
                // Step 3a-2: Instantiate player 2 as a computer player
                playerTwo = new ComputerPlayer("");
            } 
            else if(numberOfHumanPlayers == 2)      // Step 3b: If 2 players are playing
            {
                // Step 3b-2: Ask for second player name
                nameInput = "";
                nameEmpty = true;

                while (nameEmpty)
                {
                    // Step 3a-1: Ask for first player name
                    Console.Write("Player 2, please enter your name: ");
                    nameInput = Console.ReadLine();


                    if (String.IsNullOrEmpty(nameInput))
                    {
                        Console.WriteLine("\nPlease enter a name.");
                    }
                    else
                    {
                        nameEmpty = false;
                    }
                }

                // Step 3b-3: Instantiate player 2 as a human player
                playerTwo = new HumanPlayer(nameInput);
            }
        }

        public void CompareGestures()
        {
            // Step 6-1: Display gestures of player 1 and player 2
            Console.WriteLine($"\n{playerOne.name} plays {playerOne.chosenGesture}");
            Console.WriteLine($"{playerTwo.name} plays {playerTwo.chosenGesture}");

            string p1Gesture = playerOne.chosenGesture;
            string p2Gesture = playerTwo.chosenGesture;

            // Step 6-2a: If player 1 and player 2 plays the same gesture                   
            if (p1Gesture == p2Gesture)
            {
                // Step 7 - 2a - 1: It is a tie
                Console.WriteLine("It is a tie.\nThe round ends in a tie");
            }
            // Step 6-2b: If player 1 plays Rock and player 2 plays Scissors or Lizard, OR-
            // If player 1 plays Scissors and player 2 plays Paper or Lizard, OR-
            // If player 1 plays Paper and player 2 plays Rock or Spock, OR-
            // If player 1 plays Lizard and player 2 plays Spock or Paper, OR-
            // If player 1 plays Spock and player 2 plays Scissors or Rock.            
            else if ((p1Gesture == "rock" && (p2Gesture == "scissors" || p2Gesture == "lizard"))
                || (p1Gesture == "scissors" && (p2Gesture == "paper" || p2Gesture == "lizard"))
                || (p1Gesture == "paper" && (p2Gesture == "rock" || p2Gesture == "Spock"))
                || (p1Gesture == "lizard" && (p2Gesture == "Spock" || p2Gesture == "paper"))
                || (p1Gesture == "Spock" && (p2Gesture == "scissors" || p2Gesture == "rock")))
            {
                // Step 7-2b-1:  player 1 wins the round
                Console.WriteLine($"{playerOne.chosenGesture} beats {playerTwo.chosenGesture}");
                Console.WriteLine($"{playerOne.name} won the round.");
                ++playerOne.score;
            }
            else  
            {
                // Step 6-2c: Else, player 2 wins the round
                Console.WriteLine($"{playerTwo.chosenGesture} beats {playerOne.chosenGesture}");
                Console.WriteLine($"{playerTwo.name} won the round.");
                ++playerTwo.score;
            }
        }

        public void DisplayGameWinner()
        {

        }

        public void RunGame()
        {
            // Step 1: Display the rules of the game 
            WelcomeMessage();

            // Step 2: Ask how many human players will be playing
            int playerNum = ChooseNumberOfHumanPlayers();

            // Step 3: Depending on the number of players, create human objects
            CreatePlayerObjects(playerNum);

            Console.WriteLine($"Player 1 is {playerOne.name}, Player 2 is {playerTwo.name}");

            // Step 7: Check if a player has won 2 rounds (Best-of-Three victory condition)
            while (playerOne.score < 2 || playerTwo.score < 2)
            {
                // Step 7b: else, go back to step 4
                // Step 4: Ask a gesture player 1 will play
                playerOne.ChooseGesture();

                // Step 5: Ask a gesture human player 2 will play OR select a random gesture for computer player 2 
                playerTwo.ChooseGesture();

                // Step 6: Compare gestures of player 1 and player 2
                CompareGestures();
            }

            // Step 7a: If yes, display the winner and end the game
            
        }
    }
}
