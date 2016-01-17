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
    }
}
