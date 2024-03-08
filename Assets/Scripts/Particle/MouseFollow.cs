using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    // �Է¿� ��ǲ �׼�
    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Effect.Enable();
        inputActions.Effect.PointerMove.performed += OnPointerMove;
    }


    private void OnDisable()
    {
        inputActions.Effect.PointerMove.performed -= OnPointerMove;
        inputActions.Effect.Disable();
    }
    private void OnPointerMove(InputAction.CallbackContext context)
    {
       Vector3 mousePos = context.ReadValue<Vector2>();
        Debug.Log($"{mousePos.x}, {mousePos.y}");

        mousePos.z = 10.0f;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);  //��ũ�� ��ǥ ������ǥ�� �ٲٱ�

        transform.position = target;
    }
}
