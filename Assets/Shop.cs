using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Shop : MonoBehaviour
    {

        public List<ShopItem> ShopItems;


        public Transform ContentPanel;
        public ButtonObjectPool ButtonObjectPool;

        void Start()
        {
            RefreshDisplay();

            

        }

        public void RefreshDisplay()
        {
            AddButtons();
        }

        public void AddButtons()
        {
            foreach (var shopItem in ShopItems)
            {
                ShopItem _shopItem = shopItem;
                GameObject newButton = ButtonObjectPool.GetObject();
                newButton.transform.SetParent(ContentPanel);

                UpgradeButton upgradeButton = newButton.GetComponent<UpgradeButton>();
                upgradeButton.Setup(_shopItem, this);

            }
        }
    }
}