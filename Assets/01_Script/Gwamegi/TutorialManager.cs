using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _TTPenal;
    private int _tTIndex;

    [SerializeField] private GameObject _TTStartPenal;

    private bool _isTTStart;

    private void Update()
    {
        if (!_isTTStart) return;

        if (Input.GetMouseButtonDown(0))
        {
            _TTPenal[_tTIndex].SetActive(false);
            _tTIndex++;
            if (_TTPenal[_tTIndex] == null)
            {
                _isTTStart = false;
                _tTIndex = 0;
                _TTStartPenal.SetActive(false);
                return;
            }
            _TTPenal[_tTIndex].SetActive(true);
        }
    }

    public void TTUIStart()
    {
        _TTPenal[0].SetActive(true);
        _TTStartPenal.SetActive(true);
        //foreach (GameObject item in _TTPenal)
        //{
        //    if (_TTPenal[_tTIndex] == null) return;
        //    item.SetActive(false);
        //}
        _isTTStart = true;
    }


}
