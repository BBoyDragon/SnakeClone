using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCheckView : MonoBehaviour
{
    [SerializeField] private Button Restarter;
    private SceneCheckViewModel SceneChecker;
    public void inicializate(SceneCheckViewModel _SceneChecker)
    {
        Restarter.onClick.RemoveAllListeners();
        Restarter.onClick.AddListener(_SceneChecker.LoadGame);
    }
}
