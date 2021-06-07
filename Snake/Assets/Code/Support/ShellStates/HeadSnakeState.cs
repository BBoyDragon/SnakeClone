using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class HeadSnakeState : State,ISnakePart
{
    public override event Action EatApple = delegate () { };
    public override event Action Dead = delegate () { };
    public override Sprite StateSprite
    {
        get
        {
            if (_StateSprite == null)
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
                CheckOrUseShell(Shell.UpShell, Shell);
                break;

            case 2:
                CheckOrUseShell(Shell.RightShell, Shell);
                break;

            case 3:
                CheckOrUseShell(Shell.DownShell, Shell);
                break;

            case 4:
                CheckOrUseShell(Shell.LeftShell, Shell);
                break;

        }

    }
    private void CheckOrUseShell(ShellModel CheckableShell,ShellModel ThisShell)
    {
        if ((CheckableShell.CurentState is BorderState)||(CheckableShell.CurentState is SnakeState))
        {
            Dead.Invoke();
        }
        else if (CheckableShell.CurentState is AppleState)
        {
            EatApple.Invoke();
            CheckableShell.CurentState = new HeadSnakeState();
            CheckableShell.CurentState.Number = 1;
            ThisShell.CurentState = new StandartState();
        }
        else
        {
            CheckableShell.CurentState = new HeadSnakeState();
            CheckableShell.CurentState.Number = 1;
            ThisShell.CurentState = new StandartState();
        }
    }
}