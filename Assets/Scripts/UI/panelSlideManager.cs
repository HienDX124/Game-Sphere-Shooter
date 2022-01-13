using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelSlideManager : MonoBehaviour
{
    private bool isShowingPausePanel;
    public Animator pausePanelAnimator;

    void Awake()
    {
        isShowingPausePanel = false;
    }

    public void _ShowPausePanel()
    {
        isShowingPausePanel = !isShowingPausePanel;
        pausePanelAnimator.SetBool("show", isShowingPausePanel);
    }
}
