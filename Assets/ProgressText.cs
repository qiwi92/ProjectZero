using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class ProgressText : MonoBehaviour
    {
        public Text ProgressDisplay;

        void Update()
        {
            ProgressDisplay.text = (100*GameControl.Data.Progress).ToString("0.0") + " %";
        }
    }
}
