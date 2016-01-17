using Baricade.Client.Presentation;
using Baricade.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            controller.PlayGame();
        }
    }
}
