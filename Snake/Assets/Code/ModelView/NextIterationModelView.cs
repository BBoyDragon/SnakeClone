using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextIterationModelView 
{
    public ShellModel shell;
    public event Action StateChanged = delegate () { };

    public NextIterationModelView(ShellModel _Shell)
    {
        shell = _Shell;
    }

    public void Iteration()
    {
        shell.Reqest();
        StateChanged.Invoke();

    }


    //ShellModel [,] Field = new ShellModel [4, 4];
    //ShellModel SimpleShell = Resources.Load<ShellView>("Player");
    //public NextIterationModelView()
    //{
    //    for(int i = 0; i <= 4; i++)
    //    {
    //        for(int j = 0; j <= 4; j++)
    //        {
    //            Field[i,j]=
    //        }
    //    }
    //}
}
//_Player = GameObject.Instantiate(gameObject);