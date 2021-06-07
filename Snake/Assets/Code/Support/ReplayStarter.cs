using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayStarter : MonoBehaviour
{
    [SerializeField] private SceneCheckView ButtonView;
    private SceneCheckViewModel Loader;

    void Start()
    {
        Loader = new SceneCheckViewModel(new SceneCheckModel());
        ButtonView.inicializate(Loader);
    }
}
