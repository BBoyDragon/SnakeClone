using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class HeadSnakeState:State,ISnakePart 
{
    public int Direction
    {
        get
        {
            return Direction;
        }
        set
        {

        }
    }
    public override Sprite StateSprite
    {
        get
        {
            if (_StateSprite = null)
            {
                _StateSprite = Resources.Load<Sprite>("SnakeHeadSprite");
            }
            return _StateSprite;
        }
    }
    public override void Handle(ShellModel Shell)
    {
        switch (Direction)
        {
            case 1:
                Shell.UpShell.CurentState = new HeadSnakeState();
                Shell.CurentState = new StandartState();
                break;

            case 2:
                Shell.RightShell.CurentState = new HeadSnakeState();
                Shell.CurentState = new StandartState();
                break;

            case 3:
                Shell.DownShell.CurentState = new HeadSnakeState();
                Shell.CurentState = new StandartState();
                break;

            case 4:
                Shell.LeftShell.CurentState = new HeadSnakeState();
                Shell.CurentState = new StandartState();
                break;
                
        }

    }
}
