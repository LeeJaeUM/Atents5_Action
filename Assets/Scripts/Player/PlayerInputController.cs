using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    /// <summary>
    /// �ȴ� �ӵ�
    /// </summary>
    public float walkSpeed = 3.0f;

    /// <summary>
    /// �޸��� �ӵ�
    /// </summary>
    public float runSpeed = 5.0f;

    /// <summary>
    /// ���� �ӵ�
    /// </summary>
    float currentSpeed = 0.0f;

    /// <summary>
    /// �̵� ���
    /// </summary>
    enum MoveMode
    {
        Walk = 0,   // �ȱ� ���
        Run         // �޸��� ���
    }

    /// <summary>
    /// ���� �̵� ���
    /// </summary>
    MoveMode currentMoveMode = MoveMode.Run;

    /// <summary>
    /// ���� �̵� ��� Ȯ�� �� ������ ������Ƽ
    /// </summary>
    MoveMode CurrentMoveMode
    {
        get => currentMoveMode;
        set
        {
            currentMoveMode = value;    // ���� ����
            if (currentSpeed > 0.0f)     // �̵� ������ �ƴ��� Ȯ��
            {
                // �̵� ���̸� ��忡 �°� �ӵ��� �ִϸ��̼� ����
                MoveSpeedChange(currentMoveMode);
            }
        }
    }

    /// <summary>
    /// �Էµ� �̵� ����
    /// </summary>
    Vector3 inputDirection = Vector3.zero;  // y�� ������ �ٴ� ����

    /// <summary>
    /// ĳ���Ͱ� �̵��������� �ٶ� �� �ֵ��� ȸ��
    /// </summary>
    Quaternion targetRotation = Quaternion.identity;

    public float turnSpeed = 10.0f;

    // ������Ʈ��
    Animator animator;
    CharacterController characterController;

    // �ִϸ����Ϳ� �ؽð� �� ���
    readonly int Speed_Hash = Animator.StringToHash("Speed");
    const float AnimatorStopSpeed = 0.0f;
    const float AnimatorWalkSpeed = 0.3f;
    const float AnimatorRunSpeed = 1.0f;

    // �Է¿� ��ǲ �׼�
    PlayerInputActions inputActions;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.MoveModeChange.performed += OnMoveModeChange;
    }

    private void OnDisable()
    {
        inputActions.Player.MoveModeChange.performed -= OnMoveModeChange;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void Update()
    {
        characterController.Move(Time.deltaTime * currentSpeed * inputDirection);   // �� �� ����
        //characterController.SimpleMove(currentSpeed * inputDirection);            // �� �� �ڵ�

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);  //��ǥ ȸ������ ����
    }

    /// <summary>
    /// �̵� �Է� ó���� �Լ�
    /// </summary>
    /// <param name="context"></param>
    private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Vector3 input = context.ReadValue<Vector2>();

        inputDirection.x = input.x;     // �Է� ���� ����
        inputDirection.y = 0;
        inputDirection.z = input.y;

        if (!context.canceled)
        {
            // ������ ��Ȳ(�Է��� ������ ��Ȳ)
            Quaternion camY = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0); //ī�޶��� yȸ���� ���� ����
            inputDirection = camY * inputDirection;
            targetRotation = Quaternion.LookRotation(inputDirection);

            MoveSpeedChange(CurrentMoveMode);
        }
        else
        {
            // �Է��� ���� ��Ȳ
            currentSpeed = 0.0f;    // ���� ��Ű��
            animator.SetFloat(Speed_Hash, AnimatorStopSpeed);
        }
    }

    /// <summary>
    /// �̵� ��� ����� �Լ�
    /// </summary>
    /// <param name="context"></param>
    private void OnMoveModeChange(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (CurrentMoveMode == MoveMode.Walk)
        {
            CurrentMoveMode = MoveMode.Run;
        }
        else
        {
            CurrentMoveMode = MoveMode.Walk;
        }
    }

    /// <summary>
    /// ��忡 ���� �̵� �ӵ��� �����ϴ� �Լ�
    /// </summary>
    /// <param name="mode">������ ���</param>
    void MoveSpeedChange(MoveMode mode)
    {
        switch (mode) // �̵� ��忡 ���� �ӵ��� �ִϸ��̼� ����
        {
            case MoveMode.Walk:
                currentSpeed = walkSpeed;
                animator.SetFloat(Speed_Hash, AnimatorWalkSpeed);
                break;
            case MoveMode.Run:
                currentSpeed = runSpeed;
                animator.SetFloat(Speed_Hash, AnimatorRunSpeed);
                break;
        }
    }


    //void MoveRotate()
    //{
    //    Vector3 cameraForward = Camera.main.transform.forward;
    //    Vector3 cameraRight = Camera.main.transform.right;

    //    cameraForward.y = 0;
    //    cameraRight.y = 0;

    //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(inputDirection), 
    //                                        Time.deltaTime * rotateSpeed);
    //}
}