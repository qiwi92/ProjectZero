using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RandomTestScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void Hello()
    {
        StartCoroutine(Animate());       
    }


    public IEnumerator Animate()
    {
        yield return transform.DOPunchScale(new Vector3(0.1f, 0.1f, 1), 1).WaitForCompletion();
    }
}
