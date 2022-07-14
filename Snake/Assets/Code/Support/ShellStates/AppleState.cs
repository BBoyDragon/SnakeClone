using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class AppleState : State
{
    public AppleState(int AppleNumber)
    {
        Number = AppleNumber;
    }
    public override Sprite StateSprite
    {
        get
        {
            if (_StateSprite == null)
            {
                _StateSprite = Resources.Load<Sprite>("AppleSprite");
            }
            return _StateSprite;
        }
    }

    public override void Handle(ShellModel Shell)
    {
        Debug.Log("Apple");
    }
}
