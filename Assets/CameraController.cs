using DG.Tweening;
using UnityEngine;

namespace Assets
{
    public class CameraController : MonoBehaviour
    {

        private Vector3 _initCameraPos;
        public float CameraMoveDuration;
        public float CameraOffset;

        public int CameraState = -1;


        void Start ()
        {
            _initCameraPos = transform.position;
        }
	
        // Update is called once per frame
        void Update ()
        {

        }

        public void Move()
        {
            if (CameraState == 1)
            {
                MoveOnPanelOpen(_initCameraPos, transform, CameraOffset, CameraMoveDuration, 1);
            }
            if (CameraState == -1)
            {
                MoveOnPanelOpen(_initCameraPos, transform, CameraOffset, CameraMoveDuration, -1);
            }
            CameraState *= -1;
        }

        public void MoveOnPanelOpen(Vector3 initPos, Transform transform, float offset, float moveDuration, int sign)
        {
            transform.DOMove(initPos + new Vector3(0, sign * offset, 0), moveDuration, false);
        }


    }
}
