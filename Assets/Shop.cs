using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets
{
    public class Shop : MonoBehaviour
    {
        public List<ShopItem> ShopItems;

        public List<UpgradeButton> UpgradeButtons;


        public Transform ContentPanel;
        public ButtonObjectPool ButtonObjectPool;

        public GameObject ButtonPrefab;

        [HideInInspector] public NumberFormatter NumberFormatter = new NumberFormatter();

        void Start()
        {
            RefreshDisplay();

            foreach (var shopitem in ShopItems)
            {
                shopitem.UpgradeButton.Button.onClick.AddListener(() => Purchase(shopitem));
            }
        }

        public void RefreshDisplay()
        {
            AddButtons();
        }

        public void AddButtons()
        {
            foreach (var shopItem in ShopItems)
            {                            
                ShopItemSetup(shopItem);                
            }
        }



        public void Purchase(ShopItem shopItem)
        {
            if ( shopItem.Price <= GameControl.Control.Cash)
            {
                GameControl.Control.Cash -= shopItem.Price;
                shopItem.NumUpgrades += 1;
                shopItem.UpgradeButton.LevelText.text = NumberFormatter.Format(shopItem.NumUpgrades);
                SetProgessBar(shopItem);
            }
        }


        public void ShopItemSetup(ShopItem shopItem)
        {
            shopItem.Prefab = Instantiate(ButtonPrefab);

            shopItem.UpgradeButton = shopItem.Prefab.GetComponent<UpgradeButton>();

            shopItem.UpgradeButton.Icon.sprite = shopItem.Icon;
            shopItem.UpgradeButton.NameText.text = shopItem.Name;
            shopItem.UpgradeButton.PriceText.text = NumberFormatter.Format(shopItem.Price);
            shopItem.BarImage = shopItem.UpgradeButton.Bar;
            shopItem.Prefab.transform.SetParent(ContentPanel);
        }


        public void SetProgessBar(ShopItem shopItem)
        {
            shopItem.BarImage.fillAmount =  ((float) shopItem.NumUpgrades)/10;
        }
    }
}