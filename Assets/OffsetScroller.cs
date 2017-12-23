using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScroller : MonoBehaviour {

    public float scrollSpeed;

    public Renderer rend;

	void Start () {
        rend = GetComponent<Renderer>();
	}
	

	void Update () {

        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(0, y);

        rend.material.SetTextureOffset("_MainTex", offset);
        
	}
}
