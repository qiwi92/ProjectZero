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
            SetShop();

            RefreshDisplay();

            foreach (var shopitem in ShopItems)
            {
                shopitem.UpgradeButton.Button.onClick.AddListener(() => Purchase(shopitem));               
            }
        
        }

        void Update()
        {
            foreach (var shopitem in ShopItems)
            {
                PurchasableAnimation(shopitem);
            }
        }

        private void SetShop()
        {
            ShopItems = new List<ShopItem>()
            {
                new ShopItem() { ItemType = ShopItemType.GunFireRate },
                new ShopItem() { ItemType = ShopItemType.GunDamage }
            };

            foreach (var shopItem in ShopItems)
            {
                shopItem.SetShopItem();
                shopItem.UpdateItem();
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

        public void PurchasableAnimation(ShopItem shopItem)
        {
            if (shopItem.Price <= GameControl.Data.Cash)
            {
                shopItem.ArrowAnimation.AvaialablePurchase = true;
            }
            else
            {
                shopItem.ArrowAnimation.AvaialablePurchase = false;
            }
        }


        public void Purchase(ShopItem shopItem)
        {
            if ( shopItem.Price <= GameControl.Data.Cash)
            {
                GameControl.Data.Cash -= shopItem.Price;

                shopItem.Level +=1;
                shopItem.UpdateItem();

                shopItem.UpgradeButton.LevelText.text = NumberFormatter.Format(shopItem.Level);
                shopItem.UpgradeButton.PriceText.text = NumberFormatter.Format(shopItem.Price);
                SetProgessBar(shopItem);
            }
        }


        public void ShopItemSetup(ShopItem shopItem)
        {
            shopItem.Prefab = Instantiate(ButtonPrefab);
            shopItem.UpgradeButton = shopItem.Prefab.GetComponent<UpgradeButton>();
            shopItem.UpgradeButton.NameText.text = shopItem.Name;
            shopItem.UpgradeButton.Icon.sprite = shopItem.Icon;
            shopItem.UpgradeButton.PriceText.text = NumberFormatter.Format(shopItem.Price);
            shopItem.BarImage = shopItem.UpgradeButton.Bar;
            shopItem.Prefab.transform.SetParent(ContentPanel);

            shopItem.ArrowAnimation = shopItem.UpgradeButton.ArrowAnimation;
            shopItem.UpgradeButton.LevelText.text = NumberFormatter.Format(shopItem.Level);
            SetProgessBar(shopItem);
        }


        public void SetProgessBar(ShopItem shopItem)
        {
            shopItem.BarImage.fillAmount =  ((float) shopItem.Level)/10;
        }
        
        

    
    }
}