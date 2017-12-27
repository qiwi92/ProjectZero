using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class KillCountDisplay : MonoBehaviour
    {

        public Text KillText;
	    private NumberFormatter _numberFormatter = new NumberFormatter();
        void Update ()
        {
            KillText.text = _numberFormatter.Format(GameControl.Data.Kills);
        }
    }
}
