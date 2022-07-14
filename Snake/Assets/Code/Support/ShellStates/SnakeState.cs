using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SnakeState : State, ISnakePart 
{
    public SnakeState(int _Number)
    {
        Number = _Number;
    }
    public override Sprite StateSprite
    {
        get
        {
            if(_StateSprite == null)
            {
                _StateSprite = Resources.Load<Sprite>("SnakeHeadSprite");
            }
            return _StateSprite;
        }
    }
    public override void Handle(ShellModel Shell)
    {
        CheckOrUseShell(Shell.NextShell, Shell);
    }
    public void CheckOrUseShell(ShellModel CheckableShell, ShellModel ThisShell)
    {
        CheckableShell.CurentState = new SnakeState(ThisShell.CurentState.Number);
        ThisShell.CurentState = new StandartState();
    }

}
