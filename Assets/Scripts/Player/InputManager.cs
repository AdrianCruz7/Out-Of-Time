using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private PlayerInputs inputActions;

    public event Action OnPause;
    public event Action<Vector2> OnMovePerformed;
    public event Action<Vector2> OnMoveCancelled;
    public event Action OnRoll;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        inputActions = new PlayerInputs();

        inputActions.Movement.Move.performed += SignalMovePerformed;
        inputActions.Movement.Move.canceled += SignalMoveCancelled;
        inputActions.Movement.Roll.performed += SignalRoll;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void SignalPause(InputAction.CallbackContext context)
    {
        OnPause?.Invoke();
    }

    void SignalMovePerformed(InputAction.CallbackContext context)
    {
        //Debug.Log("Movement");
        OnMovePerformed?.Invoke(context.ReadValue<Vector2>());
    }

    void SignalMoveCancelled(InputAction.CallbackContext context)
    {
        //Debug.Log("Cancelled");
        OnMoveCancelled?.Invoke(Vector2.zero);
    }

    void SignalRoll(InputAction.CallbackContext context)
    {
        OnRoll?.Invoke();
    }
}