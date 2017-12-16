using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets
{
    public class DebreeController : MonoBehaviour {
    
        
    
        public int itemCount;
        public int activeItemCount;

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


        public List<Item> inactiveItems;
        public List<Item> items;
        public List<Item> notCatchedItems;
        public List<int> notCatchedIds;



        private ItemIds dropedItem;

        private Item itemPlaceholder;
    
    
        public void SetUp () {

            var aItem = ItemPrefabs[1].Prefab;

            inactiveItems = new List<Item>();
            items = new List<Item>();
            notCatchedItems = new List<Item>();
            notCatchedIds = new List<int>();

            for (int i = 0; i < itemCount; i++)
            {
                var randomNum = (int) Random.Range(0, 10000);
                var randomSpeed = Random.Range(0.9f, 1.1f);

                ItemIds itemType = GetItemId(randomNum);
                GameObject prefab = GetPrefab(itemType);

                inactiveItems.Add(new Item(itemType, Instantiate(prefab), randomSpeed));
    
            }

            foreach (var item in inactiveItems)
            {
                SetInactive(item);
            }
            

            for(int i =0; i<activeItemCount; i++)
            {
                var randomItemId = (int)Random.Range(0, inactiveItems.Count);

                items.Add(inactiveItems[randomItemId]);
            }

            foreach (var item in items)
            {
                Reset(item);
            }
        }
    	
    	void Update ()
        {
 

    		foreach(var item in items)
            {
                if (item.itemPrefab.transform.position.y < -height)
                {
                    inactiveItems.Add(item);
                    notCatchedItems.Add(item);

                }

                item.itemPrefab.transform.position += Vector3.down*Time.deltaTime*speedFactor*item.speed;
            }

            if (items.Count < activeItemCount)
            {
                var activeItems = items.Count;
                for (int i = 0; i < activeItemCount - activeItems; i++)
                {
                    var randomItemId = (int)Random.Range(0, inactiveItems.Count);

                    items.Add(inactiveItems[randomItemId]);
                }
            }

            if (notCatchedItems.Count > 0)
            {
                foreach (var item in notCatchedItems)
                {
                    notCatchedItems.Remove(item);
                    Destroy(item.itemPrefab);
                }
            }

        }




        public void SetInactive(Item item)
        {
           item.itemPrefab.transform.position = new Vector3(0, height, 0);                 
        }

        public void Reset(Item item)
        {
            float y = Random.Range(0, height / 2);
            float x = Random.Range(-width / 2, width / 2);

            item.itemPrefab.transform.position = new Vector3(x, height / 2 + y, 0);
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