using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{ /// <summary>
/// Klassen food ärver gameobject och använder interface Irenderable. Character för char vid utskrift.
/// </summary>
  public  class Food: GameObject, IRenderable
    {
        public char Character { get; set; }

        public Food (char food, int x, int y):base(x, y)
        {
            Character = food;
            
        }

    }
}
