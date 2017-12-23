using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets
{
    public class tractorBeamController : MonoBehaviour
    {



        [HideInInspector] public DebreeController DebreeController;
        [HideInInspector] public int stoneCount = 0;
        [HideInInspector] public int coinCount = 0;
        [HideInInspector] public int redStoneCount = 0;
        [HideInInspector] public int crystalCount = 0;


        public UnityEngine.UI.Text StoneCountText;
        public UnityEngine.UI.Text CoinCountText;
        public UnityEngine.UI.Text RedStoneCountText;
        public UnityEngine.UI.Text CrystalCountText;

        public UnityEngine.UI.Text upgradeText;
        public UnityEngine.UI.Text costText;
        public UnityEngine.UI.Text beamStrengthText;

        public UnityEngine.UI.Button upgradeButton;
        private int level;

        private float beamStrength = 0.005f;
        public LineRenderer lineRenderer;
        private Item closestItem;


        private int beamLevel = 0;
        private int cost = 0;
        private int costBase = 10;

        private int closestItemId;



        void Start()
        {
            UnityEngine.UI.Button btn = upgradeButton.GetComponent<UnityEngine.UI.Button>();
            btn.onClick.AddListener(Uprgade);
        }


        void Update()
        {

            var playerPosition = transform.position;

            float minDistance = float.MaxValue;

            for (var itemId = 0; itemId < DebreeController.Items.Count; itemId++)
            {
                var itemPosition = DebreeController.Items[itemId].itemPrefab.transform.position;

                var distance = Vector3.SqrMagnitude(itemPosition - playerPosition);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestItem = DebreeController.Items[itemId];
                    closestItemId = itemId;
                }
            }

            var closestItemPosition = closestItem.itemPrefab.transform.position;

            closestItem.itemPrefab.transform.position += Vector3.Normalize(playerPosition - closestItemPosition) * beamStrength;

            if (Vector3.Distance(playerPosition, closestItemPosition) < 0.8)
            {
                DebreeController.Reset(closestItem);
                DebreeController.Items[closestItemId].itemPrefab.GetComponent<AudioSource>().Play();


                if (closestItem.id == ItemIds.stone)
                {
                    stoneCount += 1;
                }
                if (closestItem.id == ItemIds.coin)
                {
                    coinCount += 1;
                }
                if (closestItem.id == ItemIds.redStone)
                {
                    redStoneCount += 1;
                }
                if (closestItem.id == ItemIds.crystal)
                {
                    crystalCount += 1;
                }

            }

            lineRenderer.SetPositions(new Vector3[] { playerPosition, closestItemPosition });

            StoneCountText.text = stoneCount.ToString();
            CoinCountText.text = coinCount.ToString();
            RedStoneCountText.text = redStoneCount.ToString();
            CrystalCountText.text = crystalCount.ToString();




        }

        void Uprgade()
        {
            if (stoneCount >= cost)
            {
                stoneCount -= cost;
                level += 1;
                cost += 3;
                beamStrength = beamStrength * 2;

                upgradeText.text = "Level: " + level;
                costText.text = "Cost: " + cost;
                beamStrengthText.text = "Beam Strength: " + beamStrength;
            }

        }

    }
}