using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Interface för char Character. Kräver char Charakter för klasser som ärver den.
    /// </summary>
   public  interface IRenderable
    {
        public char Character { get; set; }
        
    }
}
