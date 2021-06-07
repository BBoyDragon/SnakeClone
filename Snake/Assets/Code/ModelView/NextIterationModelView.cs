using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextIterationModelView: IComparable<NextIterationModelView>
{
    public ShellModel shell;
    public event Action StateChanged = delegate () { };
    public NextIterationModelView nextPart
    {
        get;
        set;
    }

    public int CompareTo(NextIterationModelView  comparePart)
    {
        return shell.CurentState.Number.CompareTo(comparePart.shell.CurentState.Number);
    }

    public NextIterationModelView(ShellModel _Shell)
    {
        shell = _Shell;
    }

    public void IterationStart()
    {
        StateChanged.Invoke();
        shell.Reqest();
        

    }
    public NextIterationModelView NextGo()
    {
        IterationStart();
        if (nextPart != null)
        {
            nextPart.NextGo();
        }
        return nextPart;
    }

    public NextIterationModelView  SetNext(NextIterationModelView snakeShell)
    {
        snakeShell.shell.NextShell = shell;
        nextPart = snakeShell;

        return snakeShell;
    }

}