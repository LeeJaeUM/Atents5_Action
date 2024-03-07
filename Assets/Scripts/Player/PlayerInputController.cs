using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 5.0f;
    [SerializeField]float currentSpeed = 0.0f;

    enum MoveMode
    {
        Walk = 0,
        Run
    }
    MoveMode moveSpeedMode = MoveMode.Run;

    MoveMode MoveSpeedMode
    {
        get => moveSpeedMode;
        set
        {
            moveSpeedMode = value;
            switch (moveSpeedMode)
            {
                case MoveMode.Walk: currentSpeed = walkSpeed;
                    anim.SetFloat(Speed_Hash, AnimatorWalkSpeed);
                    break; 
                case MoveMode.Run:  currentSpeed = runSpeed;
                    anim.SetFloat(Speed_Hash, AnimatorRunSpeed);
                    break; 
            }
        }
    }

    readonly int Speed_Hash = Animator.StringToHash("Speed");
    const float AnimatorStopSpeed = 0.0f;
    const float AnimatorWalkSpeed = 0.3f;
    const float AnimatorRunSpeed = 1.0f;

    Animator anim;
    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.MoveModeChange.performed += OnMoveModeChange;
    }


    private void OnDisable()
    {
        inputActions.Player.MoveModeChange.performed -= OnMoveModeChange;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {

    }
    private void OnMoveModeChange(InputAction.CallbackContext context)
    {
       if(moveSpeedMode == 0)
        {
            MoveSpeedMode = MoveMode.Run;
        }
        else
        {
            MoveSpeedMode = MoveMode.Walk;
        }
    }
}
