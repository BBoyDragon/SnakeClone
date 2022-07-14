using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class SceneCheckModel
{
    public void LoadDeathScrean()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGameScrean()
    {
        SceneManager.LoadScene(0);
    }
}
