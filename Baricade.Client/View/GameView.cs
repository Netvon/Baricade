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
            Console.WriteLine("Waar wil je heen?");
        }

        public String GetDirection()
        {
            bool isCorrect = false;
            String input = "";

            while (!isCorrect)
            {
                input = Console.ReadLine();
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

        private bool CheckInput(String input)
        {
            
            switch (input)
            {
                case ("Up"):
                    return true;
                case ("Down"):
                    return true;
                case ("Left"):
                    return true;
                case ("Right"):
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
