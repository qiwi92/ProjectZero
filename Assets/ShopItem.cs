using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public enum ShopItemType
    {
        GunFireRate = 1,
        GunDamage = 2
    }


    //[System.Serializable]
    public class ShopItem
    {
        public string Name;
        public float Price;
        public Sprite Icon;
        public ShopItemType ItemType;
        [HideInInspector] public Image BarImage;
        [HideInInspector] public ArrowAnimation ArrowAnimation;
        [HideInInspector] public int Level;
        [HideInInspector] public UpgradeButton UpgradeButton;
        [HideInInspector] public GameObject Prefab;

        public void UpdateItem()
        {
            switch (ItemType)
            {
                case ShopItemType.GunFireRate:
                    Name = "Fire Rate";
                    Gun.FireRateLevel = Level;
                    Price = Gun.FireRateCost(Level);
                    break;

                case ShopItemType.GunDamage:
                    Name = "Damage";
                    Gun.DamageLevel = Level;
                    Price = Gun.DamageCost(Level);                
                    break;
            }

        }

        public void SetShopItem()
        {
            switch (ItemType)
            {
                case ShopItemType.GunFireRate:
                    Debug.Log(Gun.FireRateLevel);
                    Level = Gun.FireRateLevel;
                    Price = Gun.FireRateCost(Gun.FireRateLevel);
                    break;

                case ShopItemType.GunDamage:
                    Level = Gun.DamageLevel;
                    break;
            }

        }
    }
}