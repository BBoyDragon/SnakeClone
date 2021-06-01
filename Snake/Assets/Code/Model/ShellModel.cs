using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellModel
{
    private Sprite _CurentSprite;
    private State _CurentState;

    public  ShellModel RightShell;
    public  ShellModel LeftShell;
    public ShellModel UpShell;
    public ShellModel DownShell;




    public ShellModel(State StartState)
    {
        _CurentState = StartState;
    }

    public State CurentState
    {
        set
        {
            _CurentState = value;
            _CurentSprite = _CurentState.StateSprite;

        }
    }
    public void Reqest()
    {
        _CurentState.Handle(this);
    }

}
