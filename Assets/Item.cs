using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets
{
    public enum ItemIds
    {
        stone = 1,
        coin = 2,
        crystal = 3,
        redStone = 4
    }

    public class Item
    {
        public float speed;
        public ItemIds id;
        public GameObject itemPrefab;

        public Item(ItemIds _id, GameObject _itemPrefab, float _speed)
        {
            id = _id;
            itemPrefab = _itemPrefab;
            speed = _speed;
        }


        public List<int> Rarity( ItemIds id)
        {
            if(id == ItemIds.stone)
            {
                return new List<int> { 0, 5000 };
            }
            if (id == ItemIds.coin)
            {
                return new List<int> { 5001 , 7000 };
            }
            if (id == ItemIds.redStone)
            {
                return new List<int> { 7001, 9000 };
            }
            if (id == ItemIds.crystal)
            {
                return new List<int> { 9001, 9999 };
            }
            return new List<int> { 9999, 9999 };
        }
        
        

    }
}

