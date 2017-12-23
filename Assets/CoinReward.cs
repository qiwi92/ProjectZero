using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets
{
    public class CoinReward : MonoBehaviour
    {
        public PlayerMovementController Player;
        public int CoinsOnClick;
        public GameObject CoinPrefab;

        public List<Coin> Coins;
        public float coinSpread;
        public float coinSpeed;
        public float coinForceTime;

        public NumberFormatter NumberFormatter;


        public UnityEngine.UI.Text CoinText;

        [HideInInspector] public int coinAmount;

        private List<Coin> _collectedCoins;


        public AudioSource CoinAudioSource;
        public AudioSource SpwanAudioSource;

        void Start ()
        {
            Coins = new List<Coin>();
            _collectedCoins = new List<Coin>();

            coinAmount = 0;
            NumberFormatter = new NumberFormatter();
        }
	
        // Update is called once per frame
        void Update () {

            SpawnOnMouseClick();

            
            foreach (var coin in Coins)
            {
                Vector3 direction = Vector3.Normalize(Player.transform.position - coin.GameObject.transform.position);

                if (coin.Timer < coinForceTime)
                {
                    coin.RandomDirection -= coin.RandomDirection*Mathf.Sin(coin.Timer)/(coinSpread * coin.RandomSpread);

                    Debug.Log(Mathf.Cos(coin.Timer) / (coinSpread * coin.RandomSpread));
                    coin.Timer += 0.01f;
                }
                else
                {
                    coin.RandomDirection = Vector3.zero;
                }

                coin.GameObject.transform.Translate((direction* coin.RandomSpeed + coin.RandomDirection )* Time.deltaTime * coinSpeed);

                var distanceToPlayer = Vector3.Distance(Player.transform.position,coin.GameObject.transform.position);
                if (distanceToPlayer < 0.3)
                {
                    _collectedCoins.Add(coin);
                    coin.CollectSound.Play();
                    coinAmount += 100;
                }
            }

            CoinText.text = NumberFormatter.Format(coinAmount);
            DeleteCollectedCoins(_collectedCoins);


        }


        public void SpawnOnMouseClick()
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            gameObject.transform.position = pz;

            if (Input.GetMouseButtonDown(0))
            {
                SpwanAudioSource.Play();
                for (int i = 0; i < CoinsOnClick; i++)
                {
                    float randomAngle = Random.Range(0, 2 * Mathf.PI);

                    Coin newCoin = new Coin
                    {
                        GameObject = Instantiate(CoinPrefab, pz, Quaternion.identity),
                        Timer = 0,
                        RandomDirection = new Vector3(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle), 0),
                        RandomSpread = Random.Range(0.05f, 1),
                        RandomSpeed = Random.Range(0.4f, 1.2f),
                        CollectSound = CoinAudioSource
                };
                    Debug.Log("Hello" + randomAngle);
                    Coins.Add(newCoin);
                }
            }
        }


        public void Spawn(Vector3 position,int amount)
        {
             for (int i = 0; i < amount; i++)
             {
                 float randomAngle = Random.Range(0, 2 * Mathf.PI);

                 Coin newCoin = new Coin
                 {
                     GameObject = Instantiate(CoinPrefab,position , Quaternion.identity),
                     Timer = 0,
                     RandomDirection = new Vector3(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle), 0),
                     RandomSpread = Random.Range(0.05f, 1),
                     RandomSpeed = Random.Range(0.4f, 1.2f),
                     CollectSound = CoinAudioSource
                 };
                 Debug.Log("Hello" + randomAngle);
                 Coins.Add(newCoin);
             }
        }


        public void DeleteCollectedCoins(List<Coin> collectedCoins)
        {
            if (collectedCoins.Count > 0)
            {
                foreach (var coin in collectedCoins)
                {
                    Coins.Remove(coin);
                    Destroy(coin.GameObject);
                }
            }            
        }
    }
}
