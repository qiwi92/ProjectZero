using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    public Button Button;
    public Text NameText;
    public Text PriceText;

    [HideInInspector] public Cash Cash;

    private NumberFormatter NumberFormatter = new NumberFormatter();

    public Image Icon;

    private ShopItem _shopItem;
    private Shop _upgradeList;

	void Start () {
		//Button.onClick.AddListener(Purchase);
	}

    public void Setup(ShopItem currentItem, Shop currentUpgradeList)
    {
        _shopItem = currentItem;
        NameText.text = _shopItem.UpgradeName;
        PriceText.text = NumberFormatter.Format(_shopItem.UpgradePrice);
        Icon.sprite = _shopItem.UpgradeIcon;

        _upgradeList = currentUpgradeList;
    }

    public void Purchase()
    {
        if (_shopItem.UpgradePrice > Cash.Amount)
        {
            Cash.Amount -= (int) _shopItem.UpgradePrice;
        }
    }

}
