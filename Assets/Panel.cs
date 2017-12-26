using UnityEngine;

namespace Assets
{
    [System.Serializable]
    public class Panel
    {
        public GameObject GameObject;
        [HideInInspector] public int State;
        public PanelController PanelController;
    }
}