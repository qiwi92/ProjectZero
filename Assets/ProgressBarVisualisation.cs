using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets
{ 
    public class ProgressBarVisualisation : MonoBehaviour {

        public Image Progress;

	    void Update ()
        {

            Progress.fillAmount = GameControl.Data.Progress;
	    }
    }
}
