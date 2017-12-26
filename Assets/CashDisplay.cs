using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class CashDisplay : MonoBehaviour
    {
        [HideInInspector] public Cash Cash;
        public Text CashDisplayText;
        private NumberFormatter NumberFormatter = new NumberFormatter();
    
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update ()
        {
            CashDisplayText.text = NumberFormatter.Format(Cash.Amount);
        }
    }
}
