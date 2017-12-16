using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour {

    public GameObject panel;
    public UnityEngine.UI.Button panelButton;

    public void Start()
    {
        UnityEngine.UI.Button btn = panelButton.GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(TogglePanele);
    }

    public void TogglePanele()
    {
        panel.SetActive(!panel.activeSelf);
    }
}

