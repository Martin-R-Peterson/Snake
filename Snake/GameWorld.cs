using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class GameWorld
    {
        
        /// <summary>
        /// Klassen Gameworld. Hanterar allt som händer i spelvärlden. hanterar poäng som är privat att sätta. Har Player och food operatör för att nå koordinater för mat och spelare. Time variabel för att sätta nedräkningstid. Detta kan säkert göras på ett bättre sätt, men jag har inte kommit på hur. Innehåller även en lista där typen gameobject sätt in.
        /// </summary>
        public int Points { get; private set; }

        public Player playa { get; set; }

        public Food fodd { get; set; }
        public static int time = 200;



        public GameWorld(int points, List<GameObject> lista, Player play, Food food)
        {
            
            Points = points;
            Collect = lista;
            playa = play;
            fodd = food;
            
            
        }


        public List<GameObject> Collect { get; private set; } = new List<GameObject> { };

        /// <summary>
        /// Uppdaterar alla objekt i listan Collect, som ärver abstrakta klassen Gameobject och kör deras override metoder. Time är för nedräkning, når time 0 är spelet över.
        /// </summary>
        public void Update()
        {
            foreach (var item in Collect)
            {

                if (time != 0)
                {
                    
                    item.Update();

                }
                else if (time == 0)
                {
                    GameOverTime();
                }
            }
         
        }

        /// <summary>
        /// Metod för att skapa mat, samt ge spelaren en poäng om mat plockats upp. Först en if-sats som kontrollerar om spelaren och maten befinner sig på samma position.
        /// Adderar en poäng.
        /// Skapar upp en ny random för att randomgenerera nästa plats mat dyker upp. Får inte överskrida maxvärdet på spelplan.
        /// Skapar ny mat med random kordinaterna, lägger till maten i listan och returnerar operatoren Food fodd.
        /// </summary>
        /// <returns></returns>
        public Food CreateFood()
        {
            if (playa.poss.X == fodd.poss.X && playa.poss.Y == fodd.poss.Y)
            {

                Points++;
                Random rand = new Random();
                int rx = rand.Next(1, ConsoleRenderer.SizeX-4);
                int ry = rand.Next(1, ConsoleRenderer.SizeY-4);


                Food foder = new Food('©', rx, ry);
                GameoverDirection();
                //Tail svansi = new Tail('-', playa.poss.X, playa.poss.Y);
                Collect.Add(foder);
                fodd = foder;
                time = 200;
                return fodd;
            }
            return fodd;
        }


        
        /// <summary>
        /// Hanterar positionen för svansen när mat plockas upp. ökar eller minskar en position för att inte mat och spelaren ska vara på samma plats och bli gameover, skapar mat.
        /// </summary>
        public void GameoverDirection()
        {
            if (playa._direction == Direction.up)
            {
                Tail Tail = new Tail('-', playa.poss.X, playa.poss.Y +1);
                playa.taejl.Insert(0, Tail);
            }
            if (playa._direction == Direction.down)
            {
                Tail Tail = new Tail('-', playa.poss.X, playa.poss.Y - 1);
                playa.taejl.Insert(0, Tail);
            }
            if (playa._direction == Direction.left)
            {
                Tail Tail = new Tail('-', playa.poss.X + 1, playa.poss.Y);
                playa.taejl.Insert(0, Tail);
            }
            if (playa._direction == Direction.right)
            {
                Tail Tail = new Tail('-', playa.poss.X - 1, playa.poss.Y);
                playa.taejl.Insert(0, Tail);
            }

        }
        /// <summary>
        /// Gameover metod, skriver ut när spelaren och svansen korsar varandra. Alltså möts på samma koordinat. Även utskrift om spelaren väljer att avbryta spelet.
        /// </summary>
        /// <returns></returns>
        public bool GameOver(bool b)
        {
           if (b== false)
            {
                Console.Clear();
                Console.WriteLine("Tråkigt att du inte vill spela mer! :(");
                return false;
            }
            
            
            foreach(var item in playa.taejl)
            {
                if (item.tailx == playa.poss.X && item.taily == playa.poss.Y)
                {
                    Console.Clear();
                    string title = @"  
                                         _______  _______  _______  _______    _______           _______  _______ 
                                        (  ____ \(  ___  )(       )(  ____ \  (  ___  )|\     /|(  ____ \(  ____ )
                                        | (    \/| (   ) || () () || (    \/  | (   ) || )   ( || (    \/| (    )|
                                        | |      | (___) || || || || (__      | |   | || |   | || (__    | (____)|
                                        | | ____ |  ___  || |(_)| ||  __)     | |   | |( (   ) )|  __)   |     __)
                                        | | \_  )| (   ) || |   | || (        | |   | | \ \_/ / | (      | (\ (   
                                        | (___) || )   ( || )   ( || (____/\  | (___) |  \   /  | (____/\| ) \ \__
                                        (_______)|/     \||/     \|(_______/  (_______)   \_/   (_______/|/   \__/
                                                                          ";
                    Console.WriteLine(title);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metod för när tiden tar slut.
        /// </summary>
        /// <returns></returns>
        public bool GameOverTime()
        {
            
                    Console.Clear();
                    string title = @"  
                                        __________________ _______  _______  _  _______             _______  _ 
                                        \__   __/\__   __/(       )(  ____ \( )(  ____ \  |\     /|(  ____ )( )
                                           ) (      ) (   | () () || (    \/|/ | (    \/  | )   ( || (    )|| |
                                           | |      | |   | || || || (__       | (_____   | |   | || (____)|| |
                                           | |      | |   | |(_)| ||  __)      (_____  )  | |   | ||  _____)| |
                                           | |      | |   | |   | || (               ) |  | |   | || (      (_)
                                           | |   ___) (___| )   ( || (____/\   /\____) |  | (___) || )       _ 
                                           )_(   \_______/|/     \|(_______/   \_______)  (_______)|/       (_)
                                                                          ";
                    Console.WriteLine(title);
                    return false;
       
        }



    }
}
