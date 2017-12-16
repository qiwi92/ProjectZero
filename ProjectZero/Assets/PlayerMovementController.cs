using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public float amplitude;
    public float speed;
    private Vector3 yOffSet = new Vector3(0, -3, 0);

    void Start () {
        

    }
	

	void Update () {
        transform.position = Mathf.Sin(Time.time*speed) * Vector3.right* amplitude + yOffSet;
	}
}
