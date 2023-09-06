using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        string adventurer = "";
        float stamina = 10.0f;
        float taxation = 0.2f;
        string playerChoice = "";
        float playerDamage;
        int playerHealth = 1;
        bool isNotExhausted = true;
        bool canLoseHealth = false;
        int roomNumber = 0;
        bool validInputReceived = false;
        bool gameOver = false;
        bool metPablo = false;

        //Initialize weapon stats
        float swordDamage = 30.0f;
        float claymoreDamage = 120.0f;
        float bowDamage = 20.0f;
        float confidenceDamage = 0.0f;
        bool weaponSelected = false;

        //Stat printout function
        void PrintStats(string adventurer, float Stamina, int Health, float playerDamage)
        {
            Console.WriteLine("Character:" + adventurer);
            Console.WriteLine("Stamina:" + Stamina);
            Console.WriteLine("Health:" + Health);
            Console.WriteLine("Current damage:" + playerDamage);
            return;
        }
        int GetGreaterNumber(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        //Counting function
        void List(int end)
        {
            for (int a = 0; a <= end; a++)
            {
                Console.WriteLine(a);
            }
        }
        //Counting evens function
        void ListEvenNum(int start, int end)
        {
            int count = start;
            for (start = 0; count <= end; count++)
            {
                if (count % 2 == 0)
                {
                    Console.WriteLine(count);
                }
            }
        }
        //Menu function
        string DisplayMenu(string prompt, string option1, string option2, string option3, string option4)
        {
            string playerChoice = "";
            while (playerChoice != "1" && playerChoice != "2" && playerChoice != "3" && playerChoice != "4")
            {
                //Display prompt
                Console.Clear();
                Console.WriteLine(prompt);

                //Display all options
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                if (option3 != "")
                {
                    Console.WriteLine("3." + option3);
                }
                if (option4 != "")
                {
                    Console.WriteLine("4." + option4);
                }
                //Get player input
                Console.Write(">");
                playerChoice = Console.ReadLine();


                if (playerChoice != "1" && playerChoice != "2")
                {
                    if (playerChoice == "3" && option3 != "" || playerChoice == "4" && option4 != "")
                    {
                        continue;
                    }
                    //Incorrect input notification
                    Console.WriteLine("That's not an option, traveler!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);

                    playerChoice = "";
                }
            }
            return playerChoice;
        }

        //Starting room function
        void DisplayMainMenu()
        {
            //Main menu
            weaponSelected = false;
            Console.WriteLine("The Labyrinth of Insanity");
            Console.WriteLine("Type quit at any point to exit");
            Console.WriteLine("'Welcome to the labyrinth unfortunate traveler.'");
            while (playerChoice != "1")
            {

                //Player name input
                Console.Write(">");
                adventurer = Console.ReadLine();

                Console.WriteLine("'So your name is " + adventurer + ". Are you sure that you are not mistaken?'");

                //Confirm player name choice
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write(">");
                playerChoice = Console.ReadLine();
                Console.Clear();
                if (playerChoice == "1")
                {
                    Console.WriteLine("'Mmm yes, a very delightful name indeed.'");
                }
                else if (playerChoice == "2")
                {
                    Console.WriteLine("Oh? Then what might be your name?");
                }
                else
                {
                    Console.WriteLine("'This is no time for games traveler.'");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                }
            }

            //Welcome message
            Console.WriteLine("'" + adventurer + ", you will need to keep your wits about you in here!'");
            Console.WriteLine("'However you must also be sure to have enough stamina to protect yourself.'");
            Console.WriteLine("'I will give you a single weapon for use in this maze, but only 1! I'm not running a charity here!'");

            //Weapon choice
            playerChoice = "";
            playerChoice = DisplayMenu("The old man hands you a small silver  sword, a rusty large claymore, and a wooden bow to choose from. Which do you take?", "Silver Sword", "Rusty Claymore", "Wooden Bow", "I don't need your help!");


            //Various choice outcomes
            while (weaponSelected == false)
            {
                if (playerChoice == "1")
                {
                    Console.WriteLine("'Ah, the sword? It is from a previous adventurer like you who failed to escape.'");
                    playerDamage = swordDamage;
                    Console.WriteLine("You're damage is now " + playerDamage + ".");
                    weaponSelected = true;
                }
                else if (playerChoice == "2")
                {
                    Console.WriteLine("'This claymore is so old that I can't remember how I came into possesion of it.'");
                    playerDamage = claymoreDamage;
                    Console.WriteLine("You're damage is now " + playerDamage + ".");
                    weaponSelected = true;
                }
                else if (playerChoice == "3")
                {
                    Console.WriteLine("'This bow was left behind by a particularly brave archer, however I never learned of her fate'");
                    playerDamage = bowDamage;
                    Console.WriteLine("You're damage is now " + playerDamage + ".");
                    weaponSelected = true;
                }
                else if (playerChoice == "4")
                {
                    Console.WriteLine("'You think you can survive without my help? Then go ahead and try!'");
                    playerDamage = confidenceDamage;
                    Console.WriteLine("You decide you don't need anyone's help, and storm off without a weapon, which is probably a bad move!");
                    Console.WriteLine("With your overwhelming self confidence, you decide to proceed further into the labyrinth.");
                    Console.WriteLine("Your damage is now " + playerDamage + ".");
                    Console.WriteLine("Unfortunately, you are almost instantly ambushed by monsters, however you have no weapon to defend yourself with...");
                    Console.WriteLine("As the monsters kill you without hesitation, you ponder why you decided to not take the old man's help.");
                    playerHealth = 0;
                    roomNumber = 2;
                    weaponSelected = true;
                }
                //Pause between the start to the first room of the game
                
                PrintStats(adventurer, 10, 1, playerDamage);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
                roomNumber = 1;
            }
        }

        //Room 1 decision
        void DisplayRoom1()
        {
            if (playerHealth > 0)
            {
                Console.WriteLine("There is only 1 room ahead of you, and you would feel bad returning to the old man to say you quit, Do you continue?");
                Console.WriteLine("1.Go forward");
                Console.WriteLine("2.Turn Back");
                Console.Write(">");
                playerChoice = Console.ReadLine();
                Console.Clear();
                if (playerChoice == "1")
                {
                    Console.WriteLine("You walk into the strange room and you see something more glorious than you've ever seen before.");
                    Console.WriteLine("Before you stands the almighty one, Pablo, ruler of the cosmos.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                    metPablo = true;
                    roomNumber = 2;
                }
                else if (playerChoice == "2")
                {
                    Console.WriteLine("But you just couldn't manage to muster up the courage to proceed!");
                    Console.WriteLine("'What if there are monsters in there hiding???' You thought to yourself.");
                    Console.WriteLine("You decided it would just be best to turn back to the safety of the starting room.");
                    Console.WriteLine("The old man laughs at you as you walk back in the room!");
                    Console.WriteLine("'What happened to being a brave hero?'");
                    Console.WriteLine("'Fine, sit here and wallow in fear if that's what you truly desire!'");
                    Console.WriteLine("You did as he suggested and stayed in that room til you die.");
                    Console.WriteLine("You lived a quiet life in the singular room...");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                    playerHealth = 0;
                    roomNumber = 2;
                }

            }
        }
        //Ending paths
        void DisplayEnding()
        {
            //Game over, resetting, and stamina warning
            if (playerHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have met your end in the cursed maze, and your soul wanders among the many others before you.");
                Console.WriteLine("GAME OVER");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
            }
            else if (metPablo == true)
            {
                Console.WriteLine("You gain limitless power after Pablo bestows his blessing upon you.");
                Console.WriteLine("With your incredible powers, you leap straight through the roof of the labyrinthe. The sunlight feels good on your skin.");
                Console.WriteLine("However it does not feel as good as Pablo's POWER.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.WriteLine("Congratulations! You escaped the labyrinth!");

                
            }
            //Game restarting
            Console.WriteLine("Do you wish to play again?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            playerChoice = Console.ReadLine();
            if (playerChoice.ToLower() == "1" || playerChoice.ToLower() == "yes")
            {
                Console.WriteLine("Press any key to restart");
                Console.ReadKey(true);
                Console.Clear();
                playerChoice = "";
                roomNumber = 0;
            }
            else
            {
                Console.WriteLine("Thank you for playing, please come back soon");
                Console.WriteLine("Press any key to exit the game");
                Console.ReadKey(true);
                gameOver = true;
            }
            //Stamina warning
            if (stamina <= 2)
            {
                Console.WriteLine("You're low on stamina! Be careful!");
            }
        }
        public void Run()
        {

            //Overall game loop
            while (gameOver == false)
            {
                Console.Clear();
                playerChoice = "";
                if (roomNumber == 0)
                {
                    DisplayMainMenu();
                }
                else if (roomNumber == 1)
                {
                    DisplayRoom1();
                }
                else if (roomNumber == 2)
                {
                    DisplayEnding();
                }
            }
        }
    }
}