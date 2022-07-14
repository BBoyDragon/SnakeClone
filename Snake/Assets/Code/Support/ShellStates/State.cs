using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class State
{
    public virtual event Action EatApple;
    public virtual event Action Dead;
    internal Sprite _StateSprite;
    public int Number;
    public abstract Sprite StateSprite
    {
        get;
    }
    public int Direction;

    public abstract void Handle(ShellModel Shell);
 
}
