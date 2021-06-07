using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    private NextIterationModelView IterationViewModel;
    private SpriteRenderer Renderer;
    public void Inicialize(NextIterationModelView _IterationViewModel)
    {
        IterationViewModel = _IterationViewModel;
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        IterationViewModel.StateChanged += SpriteChange;
        SpriteChange();
    }
    private void SpriteChange()
    {

        Renderer.sprite = IterationViewModel.shell._CurentSprite;
    }
    IEnumerator DelayedSpriteRender()
    {
        yield return new WaitForSeconds(1f);
        Renderer.sprite = IterationViewModel.shell._CurentSprite;
    }
}
