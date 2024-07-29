using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;
[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IDefaultActions
{
    public static InputReader Instance { get; private set; }
    Controls _controls = new Controls();
    public NotifyValue<Vector2> OnPlayer1Move = new();
    public NotifyValue<Vector2> OnPlayer2Move = new();

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
            OnPlayer1Move.Value = context.ReadValue<Vector2>();
    }

    public void OnPlayer2(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnPlayer2Move.Value = context.ReadValue<Vector2>();
    }
}
