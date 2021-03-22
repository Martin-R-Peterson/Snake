using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{/// <summary>
/// Klassen för All rendering av spelet. Tar in en world, player och en food i konstruktorn för att kunna nå deras char för renderering. Ställer även in inställningar för spelvärlden.
/// </summary>
   public class ConsoleRenderer
    {
        private GameWorld world;
        public static int SizeX { get; set; }
        public static int SizeY { get; set; }

        private Player ett { get; set; }
        private Food tva { get; set; }
        public ConsoleRenderer(GameWorld gameWorld,int sizex, int sizey, Player playy, Food tvaa)
        {
            SizeX = sizex;
            SizeY = sizey;
            Console.SetWindowSize(sizex, sizey);
            Console.SetBufferSize(sizex +2 , sizey +2 );
            Console.ForegroundColor = ConsoleColor.Green;
            // TODO Konfigurera Console-fönstret enligt världens storlek

            world = gameWorld;
            ett = playy;
            tva = tvaa;
        }

        
        /// <summary>
        /// Metod för all rendering. Poängräknare och tid/frames. foreach för svans. och för karaktär.
        /// </summary>
        public void Render()
        {
            // TODO Rendera spelvärlden (och poängräkningen)
            Console.CursorVisible=false;
            Console.SetCursorPosition(1, 1);
            Console.Write($"Poäng:{world.Points}\nTime:{GameWorld.time/15} ");
            Console.WriteLine();
            
          foreach(var item in ett.taejl)
            {
                Console.SetCursorPosition(item.tailx, item.taily);
                Console.Write(item.Character);
            }

            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)

           Console.SetCursorPosition(ett.poss.X, ett.poss.Y);
           Console.Write(ett.Character);
           
            
            
            
            Console.SetCursorPosition(tva.poss.X, tva.poss.Y);
            tva = world.CreateFood();
            Console.Write(tva.Character);
           

            


        }
        /// <summary>
        /// Metod istället för clear, tar bort varje objekt vid uppdatering istället för hela konsollen.
        /// </summary>
        public void RenderBlank()
        {
            foreach (var item in ett.taejl)
            {
                Console.SetCursorPosition(item.tailx, item.taily);
                Console.Write(' ');
            }
            Console.SetCursorPosition(ett.poss.X, ett.poss.Y);
            Console.Write(' ');
            Console.SetCursorPosition(tva.poss.X, tva.poss.Y);
            Console.Write(' ');
        }
    }
}
