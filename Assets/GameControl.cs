using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets
{
    
    public class GameControl : MonoBehaviour
    {
        public static GameControl Data;
        
  
        public float Cash;
        public float AllTimeCash;
        public int Kills;

        public float Speed;
        public float LevelLength;
        public float Progress;

        public float currentPosition;

        

        void Awake()
        {
            if (Data == null)
            {
                DontDestroyOnLoad(gameObject);
                Data = this;
            }
            else if (Data != null)
            {
                Destroy(gameObject);
            }
        }


        
    }

}