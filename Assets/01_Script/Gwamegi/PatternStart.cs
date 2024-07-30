using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternStart : MonoBehaviour
{
    private CustomPattern _customPattern;

    private void Start()
    {
        _customPattern = GetComponent<CustomPattern>();

        _customPattern.Pattern();

        StartCoroutine(AddPattern());
    }

    private IEnumerator AddPattern()
    {
        yield return new WaitForSeconds(5f);
        _customPattern.Pattern();
        StartCoroutine(AddPattern());
    }
}
