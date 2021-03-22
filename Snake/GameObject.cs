using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{ /// <summary>
/// Abstrakta klassen gameobjekt. Använder sig av struct position och har en updatemetod klasserna som ärver ska overrida.
/// </summary>
    public abstract class GameObject
    {
         public Position poss;
        
        public GameObject(int x, int y)
        {
            poss.X = x;
            poss.Y = y;
        }

        public virtual void Update() { }
    }
}
