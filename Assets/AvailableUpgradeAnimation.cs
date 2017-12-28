using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class AvailableUpgradeAnimation : MonoBehaviour
    {
        public Image Image;
        public Shop Shop;
        private bool _avaialablePurchase = false;
        public bool PanelIsOpen = false;
        private bool _init = true;

        public float yPosUp;
        public float yPosDown;

        // Use this for initialization
        void Start ()
        {
  
            
            StartCoroutine(Hello());
        }
	
   

        private IEnumerator Hello()
        {
            while (true)
            {

                foreach (var shopItem in Shop.ShopItems)
                {
                    if (shopItem.ArrowAnimation.AvaialablePurchase && !UiController.IsAnyPanelOpen) 
                    {
                        _avaialablePurchase = true;
                        break;
                    }
                    else if (!shopItem.ArrowAnimation.AvaialablePurchase || UiController.IsAnyPanelOpen)
                    {
                        _avaialablePurchase = false;
                    }
                }

                if (_avaialablePurchase == false || UiController.IsAnyPanelOpen)
                {
                    yield return Image.DOColor(new Color(0, 0, 0, 0), 0.01f);
                }


                if (_avaialablePurchase)
                {
                    yield return Image.DOColor(new Color(1, 1, 1, 1), 0.1f).WaitForCompletion();
                    yield return transform.DOLocalMoveY(yPosDown, 0.3f).WaitForCompletion();
                    yield return transform.DOLocalMoveY(yPosUp, 0.1f).WaitForCompletion();
                }
                //yield return new WaitForSeconds(1f);
            }
        }
    }
}
