using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets
{
    
    public class GameControl:MonoBehaviour
    {
        public static GameControl Data;
  
        public float Cash;
        public int Kills;

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