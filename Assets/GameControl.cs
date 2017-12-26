using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets
{
    
    public class GameControl:MonoBehaviour
    {
        public static GameControl Control;

  
        public float Cash;
        public int Kills;

        void Awake()
        {
            if (Control == null)
            {
                DontDestroyOnLoad(gameObject);
                Control = this;
            }
            else if (Control != null)
            {
                Destroy(gameObject);
            }

            Load();
        }


        //Change when more active scenes are used
        void OnDisable()
        {
            Save();
        }


        public void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SaveGame.dat");

            Data data = new Data();
            data.Cash = Cash;
            data.Kills = Kills;

            binaryFormatter.Serialize(file,data);
            file.Close();
        }

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/SaveGame.dat"))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/SaveGame.dat", FileMode.Open);
                Data data = (Data) binaryFormatter.Deserialize(file);
                file.Close();

                Cash = data.Cash;
                Kills = data.Kills;
            }
        }

    }

    [System.Serializable]
    class Data
    {
        public float Cash;
        public int Kills;
    }
}