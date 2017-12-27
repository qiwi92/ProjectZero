using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class SaveManager : MonoBehaviour {

        public static SaveManager Instance { set; get; }
        public SaveState State;


        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Load();

            Debug.Log(Helper.Serialize<SaveState>(State));
        }

        private void Start()
        {
            GameControl.Data.Cash = State.Cash;
            GameControl.Data.Kills = State.Kills;
        }

        private void OnDisable()
        {
            Save();
        }

        public void Save()
        {
            SetState();
            PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(State));
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey("save"))
            {
                State = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
            }
            else
            {
                State = new SaveState();
                Save();
                Debug.Log("No SaveGame was found, created a new one");
            }
        }

        public void SetState()
        {
            State.Cash = GameControl.Data.Cash;
            State.Kills = GameControl.Data.Kills;
        }


    }
}