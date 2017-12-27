using System;
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
            GetSaveState();
        }

        private void GetSaveState()
        {
            GameControl.Data.Cash = State.Cash;
            GameControl.Data.AllTimeCash = State.AllTimeCash;
            GameControl.Data.Kills = State.Kills;

            Gun.FireRateLevel = State.FireRateLevel;
            Gun.DamageLevel = State.DamageLevel;

        }

        private void OnDisable()
        {
            Save();
        }

        public void Save()
        {
            SetSaveState();
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

        public void SetSaveState()
        {
            State.Cash = GameControl.Data.Cash;
            State.AllTimeCash = GameControl.Data.AllTimeCash;
            State.Kills = GameControl.Data.Kills;

            State.FireRateLevel = Gun.FireRateLevel;
            State.DamageLevel = Gun.DamageLevel;
        }


        void OnGUI()
        {
            //Delete all of the PlayerPrefs settings by pressing this Button
            if (GUI.Button(new Rect(100, 200, 200, 60), "Reset Data"))
            {
                State = new SaveState();
                GetSaveState();
            }
        }

    }
}