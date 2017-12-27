using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class CashDisplay : MonoBehaviour
    {
        public Text CashDisplayText;
        private NumberFormatter NumberFormatter = new NumberFormatter();
    
        void Update ()
        {
            CashDisplayText.text = NumberFormatter.Format(GameControl.Data.Cash);
        }
    }
}
