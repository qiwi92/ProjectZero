using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets
{
    public class DebreeController : MonoBehaviour {

        public int ItemCount;
        public int ActiveItemCount;

        public float width;
        public float height;
        public float speedFactor;


        public GameObject stonePrfab;
        public GameObject coinPrefab;
        public GameObject redStonePrefab;
        public GameObject crystalPrefab;

        public List<ItemPrefab> ItemPrefabs;

        [System.Serializable]
        public struct ItemPrefab
        {
            public ItemIds ItemId;
            public GameObject Prefab;
        }

        public List<Item> Items;
        public List<int> ActiveItemIds;
        public List<Item> InactiveItems;


        private ItemIds dropedItem;

        private Item itemPlaceholder;
    
    
        public void SetUp ()
        {

            var aItem = ItemPrefabs[1].Prefab;


            Items = new List<Item>();
            InactiveItems = new List<Item>();

        }
    	



    	void Update ()
        {
            if (ItemCount < ActiveItemCount)
            {
                for (int i = 0; i < ActiveItemCount - ItemCount;i++)
                {
                    var randomNum = (int)Random.Range(0, 10000);
                    var randomSpeed = Random.Range(0.9f, 1.1f);

                    ItemIds itemType = GetItemId(randomNum);
                    GameObject prefab = GetPrefab(itemType);
                    Item newItem = new Item(itemType, Instantiate(prefab), randomSpeed);
                    Reset(newItem);
                    Items.Add(newItem);
                    ItemCount += 1;
                }
            }

            foreach (var item in Items)
            {
                if (item.itemPrefab.transform.position.y < -height)
                {
                    InactiveItems.Add(item);
                    ItemCount -= 1;
                }

                Move(item);

                
            }

            DestroyItems();

        }

        public void DestroyItems()
        {
            if (InactiveItems.Count > 0)
            {
                foreach (var inactiveItem in InactiveItems)
                {
                    Items.Remove(inactiveItem);
                    Destroy(inactiveItem.itemPrefab);
                }
            }
            
        }



        public void Reset(Item item)
        {
            float y = Random.Range(0, height / 2);
            float x = Random.Range(-width / 2, width / 2);

            item.itemPrefab.transform.position = new Vector3(x, height / 2 + y, 0);
        }

        public void Move(Item item)
        {
            item.itemPrefab.transform.position += Vector3.down * Time.deltaTime * item.speed;
        }




        public ItemIds GetItemId(int randomNumber)
        {
            if (randomNumber >= 0 && randomNumber <= 5000)
            {
                return ItemIds.stone;
            }
            if (randomNumber >= 5001 && randomNumber <= 7500)
            {
                return ItemIds.coin;
            }
            if (randomNumber >= 7501 && randomNumber <= 8500)
            {
                return ItemIds.redStone;
            }
            if (randomNumber >= 8501 && randomNumber <= 9999)
            {
                return ItemIds.crystal; ;
            }
            return ItemIds.stone;
        }



        public GameObject GetPrefab(ItemIds id)
        {
            //return ItemPrefabs.Single(item => item.ItemId == id).Prefab;

            if (id == ItemIds.stone)
            {
                return stonePrfab;
            }
            if (id == ItemIds.coin)
            {
                return coinPrefab;
            }
            if (id == ItemIds.redStone)
            {
                return redStonePrefab;
            }
            if (id == ItemIds.crystal)
            {
                return crystalPrefab; ;
            }
            return stonePrfab;
        }
    }
}