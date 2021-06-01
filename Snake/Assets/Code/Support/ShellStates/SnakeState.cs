using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SnakeState : State, ISnakePart 
{
    public int Direction
    {
        set
        {

        }
    }
    public override Sprite StateSprite
    {
        get
        {
            if(_StateSprite = null)
            {
                _StateSprite = Resources.Load<Sprite>("SnakeSprite");
            }
            return _StateSprite;
        }
    }
    public override void Handle(ShellModel Shell)
    {

    }
}                         