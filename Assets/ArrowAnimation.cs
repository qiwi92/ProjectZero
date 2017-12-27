using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace Assets
{
    public class ArrowAnimation : MonoBehaviour
    {
        public Image Image;
        public bool AvaialablePurchase;
        private bool _init = true;

        public float yPosUp;
        public float yPosDown;

        // Use this for initialization
        IEnumerator Start()
        {
            if (_init)
            {
                yield return new WaitForSeconds(1);
                _init = false;
            }

            StartCoroutine(AnimateArrow());
        }



        public IEnumerator AnimateArrow()
        {
            while (true)
            {
                if (AvaialablePurchase == false)
                {
                    yield return Image.DOColor(new Color(0, 0, 0, 0), 0.2f).WaitForCompletion();
                }


                if (AvaialablePurchase)
                {
                    yield return Image.DOColor(new Color(1, 1, 1, 1), 0.2f).WaitForCompletion();
                    yield return transform.DOLocalMoveY(yPosDown, 0.3f).WaitForCompletion();
                    yield return transform.DOLocalMoveY(yPosUp, 0.1f).WaitForCompletion();
                }
            }
        }
    }
}
