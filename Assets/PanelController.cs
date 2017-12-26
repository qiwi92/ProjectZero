using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets
{
    public class PanelController : MonoBehaviour {

        public GameObject Panel;
        public Button PanelButton;

        public GameObject Player;
        private Vector3 _initPanelPos;
        
        public float PanelInactiveOffset;
        public float MoveDuration;

    


        private int _panelState;

        public void Start()
        {
            _panelState = -1;
            Panel.GetComponent<RectTransform>().position -= new Vector3(0,PanelInactiveOffset,0);

            _initPanelPos = Panel.GetComponent<RectTransform>().position;

        }

        public void Move()
        {
            if (_panelState == 1)
            {
                MoveOnPanelOpen(_initPanelPos, Panel.GetComponent<RectTransform>(), PanelInactiveOffset,MoveDuration,-1);
            }
            if (_panelState == -1)
            {
                MoveOnPanelOpen(_initPanelPos, Panel.GetComponent<RectTransform>(), PanelInactiveOffset, MoveDuration, 1);
            }
            _panelState *= -1;
        }

        public void MoveOnPanelOpen(Vector3 initPos,Transform transform,float offset,float moveDuration,int sign)
        {
            transform.DOMove(initPos +new Vector3(0, sign*offset, 0), moveDuration, false);
        }

        public int GetPanelState()
        {
            return _panelState;
        }

        public int SetPanelState(int panelState)
        {
            return _panelState = panelState;
        }
    }
}

