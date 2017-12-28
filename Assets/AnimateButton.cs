using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NUnit.Framework.Constraints;
using UnityEngine.UI;

public class AnimateButton : MonoBehaviour
{


    void Start()
    {

    }
    public void Animate()
    {
        StartCoroutine(_animateButton());
    }



    private IEnumerator _animateButton()
    {

        yield return transform.DOScale(new Vector3(1.1f, 1.15f, 1), 0.1f).WaitForCompletion();
        yield return transform.DOScale(new Vector3(1, 1, 1), 0.1f).WaitForCompletion();
    
    }
}
