using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.View
{
    public class GameView
    {
        public int ShowTurn(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("Speler " + number + " is aan de beurt");
            Console.WriteLine("Kies een pion om mee te spelen");

            int input = 0;
            bool isCorrect = false;
            while(!isCorrect)
            {              
                int.TryParse(Console.ReadLine(), out input);
                if (input > 0 && input <= 4)
                {
                    isCorrect = true;
                }                                 
            }
            return input;
            
        }

        public void Move(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Je hebt " + number + " zetten over");
            Console.WriteLine("Waar wil je heen? <↑> <↓> <→> <←>");
        }

        public string GetDirection()
        {
            bool isCorrect = false;
            string input = "";

            while (!isCorrect)
            {
                input = Console.ReadLine();

                if (input.ToLower() == "reset")
                    return input;

                isCorrect = CheckInput(input);
            }
            Console.WriteLine(input);
            return input;           
        }

        public void WrongMove()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Deze zet is niet mogelijk");
        }

        private bool CheckInput(string input)
        {
            
            switch (input.ToLower())
            {
                case ("up"):
                    return true;
                case ("down"):
                    return true;
                case ("left"):
                    return true;
                case ("right"):
                    return true;
                default:
                    return false;
            }
        }

        public void setCurser()
        {
            Console.SetCursorPosition(0, 18);
        }
    }
}
