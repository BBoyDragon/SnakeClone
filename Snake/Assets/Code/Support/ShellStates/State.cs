using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    internal Sprite _StateSprite;
    public abstract Sprite StateSprite
    {
        get;
    }

    public abstract void Handle(ShellModel Shell);
 
}
