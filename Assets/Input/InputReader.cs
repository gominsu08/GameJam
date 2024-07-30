using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader", fileName = "InputReader")]
public class InputReader : ScriptableObject, IDefaultActions, IBossActions
{
    private static InputReader _instance;
    public static InputReader Instance
    {
        get
        {
            if (_instance == null)
                _instance = ScriptableObject.CreateInstance<InputReader>();
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }
    public Controls controls;

    public Action<Vector2> OnPlayer1Move;
    public Action<Vector2> OnPlayer2Move;
    public Action<Vector2> OnBossPlayerMove;

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
        }
        controls.Default.SetCallbacks(this);
        controls.Default.Enable();
        controls.Boss.SetCallbacks(this);
        controls.Boss.Enable();
        Instance = this;
    }
    private void OnDisable()
    {
        if (Instance == this)
        {
            controls.Default.Disable();
            Instance = null;
        }
    }

    public void OnPlayer1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            if (input == Vector2.zero) return;
            Vector2 filteredInput = FilterDiagonalInput(input);
            OnPlayer1Move?.Invoke(filteredInput);
        }
    }

    public void OnPlayer2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            if (input == Vector2.zero) return;
            Vector2 filteredInput = FilterDiagonalInput(input);
            OnPlayer2Move?.Invoke(filteredInput);
        }
    }

    private Vector2 FilterDiagonalInput(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0 && Mathf.Abs(input.y) > 0)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
                input.x = input.x > 0 ? 1 : -1;
            }
            else
            {
                input.x = 0;
                input.y = input.y > 0 ? 1 : -1;
            }
        }
        return input;
    }

    public void OnBossPlayerUp(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnBossPlayerMove?.Invoke(Vector2.up);
    }

    public void OnBossPlayerLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnBossPlayerMove?.Invoke(Vector2.left);
    }

    public void OnBossPlayerRight(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnBossPlayerMove?.Invoke(Vector2.right);
    }

    public void OnBossPlayerDown(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnBossPlayerMove?.Invoke(Vector2.down);
    }
}
