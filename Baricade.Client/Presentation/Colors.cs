using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.Presentation
{
    class Colors
    {
        public Colors(ConsoleColor foreground, ConsoleColor background)
        {
            Foreground = foreground;
            Background = background;
        }

        public ConsoleColor Foreground { get; }
        public ConsoleColor Background { get; }

        public static Colors WithDefaultBackground(ConsoleColor foreground)
        {
            return new Colors(foreground, DefaultBackground);
        }

        public static Colors Default => new Colors(DefaultForeground, DefaultBackground);
        public static ConsoleColor DefaultBackground => ConsoleColor.Black;
        public static ConsoleColor DefaultForeground => ConsoleColor.Gray;
    }
}
