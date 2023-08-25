using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        public void Run()
        {
            //Variable initizializing
            string adventurer;
            float stamina = 10.0f;
            float taxation = 0.2f;
            int health = 1;
            bool isNotExhausted = true;
            int roomNumber = 0;
            string weapon;

            //game bootup messages
            Console.WriteLine("The Labyrinth of Insanity");
            Console.WriteLine("'Welcome to the labyrinth unfortunate traveler.");
            Console.WriteLine("I can help you escape this nightmare, but first I require your name.'");
            
            //Player name input
            adventurer = Console.ReadLine();
            Console.WriteLine("'Mmm yes, a very delightful name indeed.'");
            
            //Welcome message
            Console.WriteLine("'" + adventurer + ", You will need to keep your wits about you in here!'");
            Console.WriteLine("'However you must also be sure to have enough stamina to protect yourself.'");
            Console.WriteLine("'I will give you a single weapon for use in this maze, but only 1! I'm not running a charity here!'");

            //Weapon choice
            Console.WriteLine("The old man hands you a silver, small sword, a rusty large claymore, and wooden bow to choose from.");
            Console.WriteLine("1. Silver Sword");
            Console.WriteLine("2. Rusty Claymore");
            Console.WriteLine("3. Wooden Bow");
            Console.WriteLine("4. I don't need your help!");
            string playerChoice = Console.ReadLine();
            if (playerChoice == "1" || playerChoice == "Sword")
            {
                Console.WriteLine("Ah, the sword? It is from a previous fool like you who failed to escape");
                weapon = "Sword";
            }
            else if (playerChoice == "2" || playerChoice == "CLaymore")
            {
                Console.WriteLine("This claymore is so old that I can't remember how I came into possesion of it");
                weapon = "Claymore";
            }
            else if (playerChoice == "3" || playerChoice == "Bow")
            {
                Console.WriteLine("This bow was left behind by a brave archer, however I never learned of her fate");
                weapon = "Bow";
            }
            else if (playerChoice == "4" || playerChoice == "I don't need your help!")
            {
                Console.WriteLine("You think you can survive without my help? Then go ahead and try!");
                weapon = "CONFIDENCE";
            }
            else
            {
                Console.WriteLine("Do you take me for a fool? Perhaps you do not deserve my help!");
            }

            //Death message and stamina warning
            if (health <= 0)
            {
                Console.WriteLine("You have met your end in the endless maze");
            }
            else if (stamina <= 2)
            {
                Console.WriteLine("You're low on stamina! Be careful!");
            }
        }
    }
}
