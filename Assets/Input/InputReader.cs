using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IDefaultActions
{
    public static InputReader Instance { get; private set; }
    Controls _controls;

    public Action<Vector2> OnPlayer1Move;
    public Action<Vector2> OnPlayer2Move;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
        }
        _controls.Default.SetCallbacks(this);
        _controls.Default.Enable();
        Instance = this;
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
                input.x = 1;
            }
            else
            {
                input.x = 0;
                input.y = 1;
            }
        }
        return input;
    }
}
