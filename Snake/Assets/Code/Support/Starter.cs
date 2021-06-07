using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Starter : MonoBehaviour
{
    [SerializeField]int FieldRange = 10;
    ShellView SimpleShell;
    NextIterationModelView Head;
    NextIterationModelView Apple;
    NextIterationModelView LastPart;


    private InputCheck Inputer;
    private SceneCheckViewModel Restarter;

    NextIterationModelView[,] FieldModel = new NextIterationModelView[10, 10];
    ShellView[,] FieldView = new ShellView[10, 10];
    List<NextIterationModelView> SnakeParts;

    public void Start()
    {
        Restarter = new SceneCheckViewModel(new SceneCheckModel());

        Inputer = new InputCheck();
        SimpleShell = Resources.Load<ShellView>("Shell");
        for (int i = 0; i < FieldRange; i++)
        {
            for (int j = 0; j < FieldRange; j++)
            {
                if ((j == 0) || (j == FieldRange - 1) || (i == 0) || (i == FieldRange - 1))
                {
                    FieldModel[i, j] = new NextIterationModelView(new ShellModel(new BorderState()));
                }
                else
                {
                    FieldModel[i, j] = new NextIterationModelView(new ShellModel(new StandartState()));
                }
            }
        }
        for (int i = 0; i < FieldRange; i++)
        {
            for (int j = 0; j < FieldRange; j++)
            {
                if ((i >= 1 && i <= FieldRange - 2) && (j >= 1 && j <= FieldRange - 2))
                {
                    FieldModel[i, j].shell.UpShell = FieldModel[i, j + 1].shell;
                    FieldModel[i, j].shell.RightShell = FieldModel[i + 1, j].shell;
                    FieldModel[i, j].shell.DownShell = FieldModel[i, j - 1].shell;
                    FieldModel[i, j].shell.LeftShell = FieldModel[i - 1, j].shell;
                }
            }
        }

        FieldModel[1, 3].shell.CurentState = new HeadSnakeState();
        FieldModel[1, 2].shell.CurentState = new SnakeState(2);
        FieldModel[1, 1].shell.CurentState = new SnakeState(3);
        Head = FieldModel[1, 3];


        SnakeParts = new List<NextIterationModelView>();

        for (int i = 0; i < FieldRange; i++)
        {
            for (int j = 0; j < FieldRange; j++)
            {
                FieldView[i, j] = GameObject.Instantiate(SimpleShell);
                FieldView[i, j].transform.position = new Vector2(i, j);
                FieldView[i, j].Inicialize(FieldModel[i, j]);
            }
        }
        StartCoroutine("iteration");
    }
    public void Update()
    {
        Inputer.Check();

    }
    IEnumerator iteration()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < FieldRange; i++)
        {
            for (int j = 0; j < FieldRange; j++)
            {
                if ((!(FieldModel[i, j].shell.CurentState is HeadSnakeState))&&(!(FieldModel[i, j].shell.CurentState is SnakeState)))
                {
                    FieldModel[i, j].IterationStart();
                }
            }
        }

        for (int i = 0; i < FieldRange; i++)
        {
            for (int j = 0; j < FieldRange; j++)
            {
                if (FieldModel[i, j].shell.CurentState is HeadSnakeState)
                {
                    Head = FieldModel[i, j];
                    SnakeParts.Add(Head);
                }
                else if (FieldModel[i, j].shell.CurentState is SnakeState)
                {
                    SnakeParts.Add(FieldModel[i, j]);
                }
            }
        }
        SnakeParts.Sort();
        LastPart = SnakeParts[SnakeParts.Count - 1];
        for (var i = 1; i < SnakeParts.Count; i++)
        {
            SnakeParts[i - 1].SetNext(SnakeParts[i]);

        }
        if (Apple == null)
        {
            var rand = new System.Random();
            var RandomShell = FieldModel[rand.Next(1, 8), rand.Next(1, 8)];
            if (!(RandomShell.shell.CurentState is SnakeState)&& !(RandomShell.shell.CurentState is HeadSnakeState))
            {
                RandomShell.shell.CurentState =new AppleState(LastPart.shell.CurentState.Number + 1);
                Apple = RandomShell;
            }
        }
        Head.shell.CurentState.Direction = Inputer.InputDirection;
        Head.shell.CurentState.Dead += Restarter.LoadReplay;
        Head.shell.CurentState.EatApple += AddPart;
        SnakeParts[0].NextGo();

        Dispolse();

        StartCoroutine("iteration");
    }
    private void AddPart()
    {
        if(!(LastPart.shell.LeftShell.CurentState is SnakeState))
        {
            LastPart.shell.LeftShell.CurentState = new SnakeState(Apple.shell.CurentState.Number);
            Apple = null;
        }
        else
        {
            LastPart.shell.RightShell.CurentState = new SnakeState(Apple.shell.CurentState.Number);
            Apple = null;
        }

    }
    private void Dispolse()
    {
        Head.shell.CurentState.EatApple -= AddPart;
        Head.shell.CurentState.Dead -= Restarter.LoadReplay;
        foreach (NextIterationModelView Snake in SnakeParts)
        {
            Snake.nextPart = null;
        }
        SnakeParts.Clear();
    }
}
