using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Klassen tail. Innehåller all information om svansen, dess karaktär och koordinater. Använder sig av interfacet IRenderable för karaktären.
    /// </summary>
   public class Tail: IRenderable
    {
        public char Character { get; set; }
        public int tailx { get; set; }
        public int taily { get; set; }

        public Tail(char C, int x, int y)
        {
            Character = C;
            tailx = x;
            taily = y;
        }
    }
}
