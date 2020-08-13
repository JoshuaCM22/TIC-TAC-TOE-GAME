using System;

namespace TIC_TAC_TOE_GAME
{
    static class Title
    {
        public static void DrawInterface()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ===========================================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                 TIC-TAC-TOE                                   ");
            Console.WriteLine("                                    GAME                                       ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   Instructions: Create a horizontal or vertical or diagonal pattern to win.   ");
            Console.WriteLine("");
            Console.WriteLine("   Controls: Enter, Left Arrow, Right Arrow, Up Arrow, Down Arrow");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   ===========================================================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                        Press enter to start the game.");
            var userPressed = Console.ReadKey();
            switch (userPressed.Key)
            {
                case ConsoleKey.Enter:
                    Console.Clear();
                    Game.StartNewGame();
                    break;
                default:
                    Console.Clear();
                    DrawInterface();
                    break;
            }
        }
    }
}