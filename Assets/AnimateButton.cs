using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NUnit.Framework.Constraints;
using UnityEngine.UI;

public class AnimateButton : MonoBehaviour
{
    public void Animate()
    {
        StartCoroutine(_animateButton());
    }

    private IEnumerator _animateButton()
    {
        yield return transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0), 0.2f).WaitForCompletion();
    }

}
