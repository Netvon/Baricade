using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Core.Fields;
using Baricade.Core;

namespace Baricade.Client.View
{
    public class GameView
    {
        public void ShowTurn(int player, int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Speler " + player + " is aan de beurt");
            Console.WriteLine("Je hebt " + number + " gegooid");
            Console.WriteLine("Kies een pion om mee te spelen");                      
        }

        public void ShowWinner(Player player)
        {
            Console.WriteLine("Speler " + player.Number + " heeft gewonnen!");
        }

        public void ShowMove(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Je hebt " + number + " zetten over");
            Console.WriteLine("Waar wil je heen? <↑> <↓> <→> <←>");
        }

        //public string GetDirection()
        //{
        //    bool isCorrect = false;
        //    string input = "";

        //    while (!isCorrect)
        //    {
        //        input = Console.ReadLine();

        //        if (input.ToLower() == "reset")
        //            return input;

        //        isCorrect = CheckInput(input);
        //    }
        //    Console.WriteLine(input);
        //    return input;           
        //}

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
            Console.SetCursorPosition(0, 19);
        }

        public void ShowBaricade(BaseField baricadeCursor)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Herplaats de Baricade");
            Console.Write($"Staat op {baricadeCursor}");
        }
    }
}
