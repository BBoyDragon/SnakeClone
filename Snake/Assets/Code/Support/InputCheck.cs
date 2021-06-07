using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class InputCheck
{
    public int InputDirection=1;

    public void Check()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            InputDirection = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            InputDirection = 4;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            InputDirection = 3;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            InputDirection = 2;
        }
    }
}
