using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public float amplitude;
    public float speed;
    public float yOffset;
    private Vector3 yOffSetVector;

    public PanelController Panel;

    void Start ()
    {

    }
	

	void Update ()
    {
        transform.position = Mathf.Sin(Time.time*speed) * Vector3.right* amplitude + ShipOffset(); 
        
    }


    public Vector3 ShipOffset()
    {
        if (Panel.GetPanelState())
        {
            return new Vector3(0, 0.5f, 0);
        }
        return new Vector3(0, yOffset, 0);
    }

}
