using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    private void Start()
    {
        _window?.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    public void Open()
    {
        _window?.SetActive(true);
    }

    public void Close()
    {
        _window?.SetActive(false);
    }
}
