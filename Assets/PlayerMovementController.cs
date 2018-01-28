using System.Collections;
using System.Collections.Generic;
using Assets;
using JetBrains.Annotations;
using UnityEngine;
using DG.Tweening;

public class PlayerMovementController : MonoBehaviour {

    public float amplitude;
    public float speed;
    public float YOffSet;

    public PanelController Panel;

    void Start ()
    {

    }
	

	void Update ()
	{
	    transform.position = Mathf.Sin(Time.time * speed) * Vector3.right * amplitude - new Vector3(0,YOffSet,0);

	}

}
