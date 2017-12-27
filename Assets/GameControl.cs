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

        void OnGUI()
        {
            //Delete all of the PlayerPrefs settings by pressing this Button
            if (GUI.Button(new Rect(100, 200, 200, 60), "Reset Data"))
            {
                Cash = 0;
                Kills = 0;
            }
        }

    }

}