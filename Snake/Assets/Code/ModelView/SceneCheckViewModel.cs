using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneCheckViewModel 
{
    public SceneCheckModel model;
    public SceneCheckViewModel (SceneCheckModel _Model)
    {
        model = _Model;
    }
    public void LoadGame()
    {
        model.LoadGameScrean();
    }
    public void LoadReplay()
    {
        model.LoadDeathScrean();
    }

 
}
