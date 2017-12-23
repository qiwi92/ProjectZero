using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class RewardController : MonoBehaviour
{

    public CircleCollider2D collider;
    public GameObject ClickableObject;
    public CoinReward Coins;

    private bool _overButton = false;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _overButton == true)
        {
            Coins.Spawn(ClickableObject.transform.position, 10);
            _overButton = false;
        }

        

    }

    void OnMouseEnter()
    {
        _overButton = true;

    }
}
