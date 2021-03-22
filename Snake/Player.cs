using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Klassen player för Spelare. Ärver abstrakta klassen gameobjekt och intefaces Irenderable och Imovable.
    /// Innehåller operatorerna char character för Uppritandet av karaktären spelare, samt direction för riktning spelaren rör sig. Konstruktorn ärver kordinater från abstrakta klassen gameobject.
    /// </summary>
   public  class Player : GameObject, IRenderable, IMovable
    {
        public char Character { get; set; }
        public Direction _direction { get; set; }

        public List<Tail> taejl = new List<Tail>();

        


        public Player(Direction direction, char charrender, List<Tail> T, int x, int y) :base(x,  y)
        {
            Character = charrender;
            _direction = direction;
            taejl = T;

        }
        /// <summary>
        /// Metod update. Kontrollerar så att spelare flyttar sig till andra änden om denne åker utanför spelkartan. Sköter all hantering av posetionering, vilken riktning spelaren ska färdas mot.
        /// Använder sig av koordinaterna från abstrakta klassen Gameobject, som i sin hämtar från structen Position. Nedräknar också tiden när spelaren rör sig. Flyttar tailen efter spelaren. 
        /// Jag tycker själv att jag kunde implementerat tidsräkningen på ett annat sätt. Men jag vet inte riktigt hur jag ska nå time utan att göra den static i gameworld. Jag testade att sköta time nedräkningen i Gameworld, men fick problemet med att ju fler svansar spelaren fick, desto fler gånger uppdaterades Update och time nedräkningen gick snabbare.
        /// </summary>
        public override void Update()
        {
            if(poss.Y >= ConsoleRenderer.SizeY -1)
            {
                poss.Y = 1;
            }
            else if (poss.X >= ConsoleRenderer.SizeX -1)
            {
                poss.X = 1;
            }
            else if (poss.Y <= 1)
            {
                poss.Y = ConsoleRenderer.SizeY -2;
            }
            else if (poss.X <= 1)
            {
                poss.X = ConsoleRenderer.SizeX -2;
            }


            GameWorld.time--;


            switch (_direction)
            {
                case Direction.up:
                   if(taejl.Count != 0)
                    {
                        taejl.RemoveAt(taejl.Count - 1);
                        Tail svans = new Tail('-', poss.X, poss.Y);
                        taejl.Insert(0, svans);

                    }
                    poss.Y -= 1;
                    break;

                case Direction.down:
                    if (taejl.Count != 0)
                    {
                        taejl.RemoveAt(taejl.Count - 1);
                        Tail svans = new Tail('-', poss.X, poss.Y);
                        taejl.Insert(0, svans);
                    }
                    poss.Y += 1;
                    break;

                case Direction.left:
                    if (taejl.Count != 0)
                    {
                        taejl.RemoveAt(taejl.Count - 1);
                        Tail svans = new Tail('-', poss.X, poss.Y);
                        taejl.Insert(0, svans);
                    }
                    poss.X -= 1;
                    break;

                case Direction.right:
                    if (this.taejl.Count != 0)
                    {
                        this.taejl.RemoveAt(this.taejl.Count - 1);
                        Tail svans = new Tail('-', poss.X, poss.Y);
                        taejl.Insert(0, svans);
                    }
                    poss.X += 1;
                    break;

                case Direction.none:
                    break;
                    
            }

           
        }
    }
}
