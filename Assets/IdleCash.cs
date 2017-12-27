using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

namespace Assets
{
    public class IdleCash : MonoBehaviour
    {
        private float cash;
        private float pastCash;
        private float initCash;
        private bool initCashCheck = true;
        private float timer = 0;
        private float integrationLimit = 0.5f;
        private float integrationTime = 0;
        public Text DisplayText;

        private NumberFormatter _numberFormatter = new NumberFormatter();

        private void Start()
        {
            
        }

        public void Update()
        {
    
            timer += Time.deltaTime;
           

            if (timer > integrationLimit)
            {
                cash = GameControl.Data.AllTimeCash;
                if (initCashCheck)
                {
                    initCash = cash;
                    initCashCheck = false;
                }
                

                integrationTime += timer;
                var cashPerSec = (cash - initCash) / integrationTime;
                DisplayText.text = "+ " +  _numberFormatter.Format(cashPerSec) + "/s";
                timer = 0;
            }
        }
    }
}