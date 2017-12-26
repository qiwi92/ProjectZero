using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    [System.Serializable]
    public class ShopItem
    {
        public string Name;
        public float Price;
        public Sprite Icon;
        [HideInInspector] public Image BarImage;
        [HideInInspector] public int NumUpgrades = 0;
        [HideInInspector] public UpgradeButton UpgradeButton;
        [HideInInspector] public GameObject Prefab;

    }
}