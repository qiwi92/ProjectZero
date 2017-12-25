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

    private NumberFormatter NumberFormatter = new NumberFormatter();

    public Image Icon;

    private ShopItem _shopItem;
    private UpgradeListController _upgradeList;

	void Start () {
		
	}

    public void Setup(ShopItem currentItem, UpgradeListController currentUpgradeList)
    {
        _shopItem = currentItem;
        NameText.text = _shopItem.UpgradeName;
        PriceText.text = NumberFormatter.Format(_shopItem.UpgradePrice);
        Icon.sprite = _shopItem.UpgradeIcon;

        _upgradeList = currentUpgradeList;
    }

}
