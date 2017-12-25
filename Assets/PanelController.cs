using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class PanelController : MonoBehaviour {

    public GameObject Panel;
    public Animator PanelAnimator;
    public UnityEngine.UI.Button PanelButton;



    private int _panelState = -1;

    public void Start()
    {
        PanelButton.onClick.AddListener(PanelAnimation);

    }




    public void PanelAnimation()
    {
        if (_panelState == 1)
        {
            PanelAnimator.SetTrigger("Close");
            
        }
        if (_panelState == -1)
        {
            PanelAnimator.SetTrigger("Open");
        }
        _panelState *= -1;
    }

    public bool GetPanelState()
    {
        if (_panelState == 1)
        {
            return true;
        }
        return false;
    }

}

