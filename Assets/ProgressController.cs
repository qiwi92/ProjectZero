using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets
{
    public class ProgressController : MonoBehaviour
    {

        public Image ProgressBarImage;
        public RectTransform RectTransformProgressBar;
        public RectTransform ShipDisplayTransform;
        private bool _isExpanded = true;


        public float YSize = 1720;




        public void ResizeProgressBar()
        {
            YSize = 1720 - scale() * 650;

            var sizeVector = new Vector2(25, YSize);

            RectTransformProgressBar.DOSizeDelta(sizeVector, 0.2f);
            _isExpanded = ! _isExpanded;
        }

        private int scale()
        {
            if (_isExpanded == true)
            {
                return 1;
            }
            return 0;
        }


        private void Update()
        {
            var pos = RectTransformProgressBar.position - new Vector3(0, YSize * (1 - GameControl.Data.Progress), 0);
            Debug.Log(YSize);
            ShipDisplayTransform.DOMoveY(pos.y, 0.2f);



            //Debug.Log(1300 * GameControl.Data.Progress);
            SetProgress();
        }

        private void SetProgress()
        {
            if (GameControl.Data.currentPosition < GameControl.Data.LevelLength)
            {
                GameControl.Data.currentPosition += GameControl.Data.Speed * Time.deltaTime;
            }
            else
            {
                GameControl.Data.currentPosition = 0;
            }

            GameControl.Data.Progress = GameControl.Data.currentPosition / GameControl.Data.LevelLength;
        }
    }
}
