using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{ /// <summary>
/// Interface för att flytta player. riktning.
/// </summary>
    public interface IMovable
    {
         Direction _direction { get; set; }
    }
}
