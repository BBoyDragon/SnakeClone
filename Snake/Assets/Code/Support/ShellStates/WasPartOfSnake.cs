using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class WasPartOfSnake : State
{
    public override Sprite StateSprite
    {
        get
        {
            if (_StateSprite == null)
            {
                _StateSprite = Resources.Load<Sprite>("sprite");
            }
            return _StateSprite;
        }
    }

    public override void Handle(ShellModel Shell)
    {
        Shell.CurentState = new StandartState();
    }
}

