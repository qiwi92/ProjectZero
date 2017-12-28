using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class UiController : MonoBehaviour
    {
        
        public List<Panel> Panels;
        public CameraController Camera;
        public AvailableUpgradeAnimation UpgradeAnimation;

        public static bool IsAnyPanelOpen = false;

        [HideInInspector] public int CameraState = -1;
        [HideInInspector] public int CameraStateB = -1; 
        private Panel activePanel; 


        void Start()
        {
            foreach (var panel in Panels)
            {
                panel.State = -1;
            }

            foreach (var panelll in Panels)
            {

                panelll.PanelController.PanelButton.onClick.AddListener(() => ActivatePanel(panelll));

            }

            


        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void ActivatePanel(Panel panel)
        {
            
            panel.PanelController.Move();
            panel.State *= -1;

            foreach (var _panel in Panels)
            {
                
                if (_panel !=panel)
                {
                    if (_panel.State == 1)
                    {
                        _panel.PanelController.Move();
                        _panel.State = -1;
                        
                    }
                    
                }
            }
            MoveCamera();
            
        }

        public void MoveCamera()
        {
            var anyPanelState = Panels.Max(x => x.State);
            Debug.Log(anyPanelState);

            if (Camera.CameraState != anyPanelState)
            {
                UpgradeAnimation.PanelIsOpen = !UpgradeAnimation.PanelIsOpen;
                Camera.Move();
                
                CameraStateB = CameraState;
                IsAnyPanelOpen = !IsAnyPanelOpen;
            }

        }

    }
}
