using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class OffsetScroller : MonoBehaviour
    {
        public Renderer rend;

        void Start()
        {
            rend = GetComponent<Renderer>();
        }

        void Update()
        {

            float y = Mathf.Repeat(Time.time * GameControl.Data.Speed, 1);
            Vector2 offset = new Vector2(0, y);

            rend.material.SetTextureOffset("_MainTex", offset);

        }
    }
}


