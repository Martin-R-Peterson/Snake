using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{

    /// <summary>
    /// Enum för direction. Gör så inte andra kommandon kan användas när man använder direction än de som är specifierade.
    /// </summary>
    public enum Direction
    {
        up,
        down,
        left,
        right,
        none
    }
    /// <summary>
    /// Struct för positioneringen.
    /// </summary>
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
    public class Program
    {
        /// <summary>
        /// Ett litet intro för spelet med information.
        /// </summary>
        static void intro()
        {
            
            Console.WriteLine("\nSnake The Game");
            Console.WriteLine("\nWatch out so the time wont run out.");
            Console.WriteLine("\nUse the arrowkeys to control the snake Press a key to start.");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it as uppercase, otherwise returns '\0'.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;
        static void Loop()
        {
            // Initialisera spelet
            const int frameRate = 15;
            List<GameObject> items = new List<GameObject>();
            List<Tail> svans = new List<Tail>();
            Player play = new Player(Direction.right, 'O', svans, 7, 4);
            Food fodd = new Food('©', 6, 8);
            GameWorld world = new GameWorld(0, items, play, fodd);


            ConsoleRenderer renderer = new ConsoleRenderer(world,120,60,play,fodd);

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            // ...
            items.Add(play);
            items.Add(fodd);
            

            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                // Använder piltangenterna för förflyttning. Förflyttar spelaren med hjälp av enum. Går ej flytta spelaren om spelaren trycker motsatt håll. Q körs gameover metod.
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Q:
                        running = world.GameOver(false);

                        break;
                    case ConsoleKey.UpArrow:
                        if (play._direction == Direction.down)
                        { 
                            break; 
                        }
                        else
                        {
                            play._direction = Direction.up;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        if (play._direction == Direction.up)
                        {
                            break;
                        }
                        else
                        {
                            play._direction = Direction.down;

                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        if (play._direction == Direction.right)
                        {
                            break;
                        }
                        else
                        {
                            play._direction = Direction.left;

                            break;
                        }
                    case ConsoleKey.RightArrow:
                        if (play._direction == Direction.left)
                        {
                            break;
                        }
                        else
                        {
                            play._direction = Direction.right;

                            break;
                        }


                        // TODO Lägg till logik för andra knapptryckningar
                        // ...
                }



                // Uppdatera världen och rendera om
                renderer.RenderBlank();
                world.Update();
                renderer.Render();
               running = world.GameOver(running);

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        public static void Main(string[] args)
        {
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            intro();// intro metoden körs.
            Loop();
            
        }

        
    }
}
