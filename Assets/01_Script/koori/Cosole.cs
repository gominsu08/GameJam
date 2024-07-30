using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cosole : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private TMP_Text _result;
    [SerializeField] private TMP_InputField _fileld;
    private string _input;

    private void Awake()
    {
        _window.SetActive(false);
    }

    public void Open()
    {
        _window.SetActive(true);
    }
    public void Close()
    {
        _window.SetActive(false);
    }

    public void Input()
    {
        _input = _fileld.text;
        _fileld.text = null ;
        Check();
    }

    private void Check()
    {
        if (_input != null)
        {
            switch (_input)
            {
                case "��":
                    _result.text = _input; break;
                case "�ϴ�":
                    _result.text = "158"; break;
                case "�����":
                    _result.text = "�״� ���̾�! �����ؾ߸� ��!"; break ;

            }
        }
        else
            _result.text = "Null";
    }
}
