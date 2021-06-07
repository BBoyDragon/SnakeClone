using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellModel
{
    public Sprite _CurentSprite;
    public  State _CurentState;

    public  ShellModel RightShell;
    public  ShellModel LeftShell;
    public ShellModel UpShell;
    public ShellModel DownShell;

    public ShellModel NextShell;




    public ShellModel(State StartState)
    {
        _CurentState = StartState;
        _CurentSprite = StartState.StateSprite;
    }

    public State CurentState
    {
        set
        {
            _CurentState = value;
            _CurentSprite = _CurentState.StateSprite;

        }
        get
        {
            return _CurentState;
        }
    }
    public void Reqest()
    {
        _CurentState.Handle(this);
    }

}
