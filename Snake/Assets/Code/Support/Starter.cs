using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
     int FieldRange=4;
    ShellView SimpleShell;

    NextIterationModelView[,] FieldModel = new NextIterationModelView [4 , 4];
    ShellView [,] FieldView = new ShellView [4, 4];

    public void Start()
    {
        SimpleShell = Resources.Load<ShellView>("Shell");
        for (int i=0; i < FieldRange; i++)
        {
            for(int j = 0; j < FieldRange; j++)
            {
                FieldModel[i, j] = new NextIterationModelView(new ShellModel(new StandartState()));
            }
        }
        for (int i = 0; i < FieldRange; i++)
        {
            for (int j = 0; j < FieldRange; j++)
            {
                FieldView[i, j] = GameObject.Instantiate(SimpleShell);
                FieldView[i, j].transform.position = new Vector2(i, j);
                FieldView[i, j].Inicialize(FieldModel[i, j]);
            }
        }
    }
}
