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
            bool isNotExhausted = true;
            int roomNumber = 0;

            //game bootup messages
            Console.WriteLine("The Labyrinth of Insanity");
            Console.WriteLine("Welcome to the labyrinth unfortunate traveler.");
            Console.WriteLine("I can help you escape this nightmare, but first I require your name.");
            
            //Player name input
            adventurer = Console.ReadLine();
            Console.WriteLine("Mmm yes, a very delightful name indeed.");
            
            //Welcome message
            Console.WriteLine(adventurer + ", You will need to keep your wits about you in here!");
            Console.WriteLine("However you must also be sure to have enough stamina to protect yourself.");
            Console.WriteLine("I will give you a single weapon for use in this maze, but only 1! I'm not running a charity here!");
        }
    }
}
