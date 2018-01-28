using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class SpeedDisplay : MonoBehaviour {

        public Text Speed;
        private NumberFormatter _numberFormatter = new NumberFormatter();


        void Update()
        {
            Speed.text = _numberFormatter.Format(GameControl.Data.Speed*3600);
        }
    }
}
