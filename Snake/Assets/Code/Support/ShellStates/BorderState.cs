using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class BorderState : State
{
    public override Sprite StateSprite
    {
        get
        {
            if (_StateSprite == null)
            {
                _StateSprite = Resources.Load<Sprite>("Bordersprite");
                Debug.Log("spritw");
            }
            return _StateSprite;
        }
    }

    public override void Handle(ShellModel Shell)
    {
        Debug.Log("try to spawn an apple");
    }
}

