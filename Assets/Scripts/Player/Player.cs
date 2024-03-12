using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
    /// ĳ������ ��ǥ�������� ȸ����Ű�� ȸ��
    /// </summary>
    Quaternion targetRotation = Quaternion.identity;

    /// <summary>
    /// ĳ���� ȸ�� �ӵ�
    /// </summary>
    public float turnSpeed = 10.0f;

    /// <summary>
    /// ���� ����� Ʈ������
    /// </summary>
    Transform weaponParent;

    /// <summary>
    /// ���� ����� Ʈ������
    /// </summary>
    Transform shiledParent;

    // �ִϸ����Ϳ� �ؽð� �� ���
    readonly int Speed_Hash = Animator.StringToHash("Speed");
    const float AnimatorStopSpeed = 0.0f;
    const float AnimatorWalkSpeed = 0.3f;
    const float AnimatorRunSpeed = 1.0f;
    readonly int Attack_Hash = Animator.StringToHash("Attack");

    // ������Ʈ��
    Animator animator;
    CharacterController characterController;
    PlayerInputController inputController;

    private void Awake()
    {
        //Transform child = transform.GetChild(2);    // root
        //child = child.GetChild(0);                  // pelvis
        //child = child.GetChild(0);                  // spine1
        //child = child.GetChild(0);                  // spine2

        //Transform spine3 = child.GetChild(0);       // spine3
        //weaponParent = spine3.GetChild(2);          // clavicle_r
        //weaponParent = weaponParent.GetChild(1);    // upperarm_r
        //weaponParent = weaponParent.GetChild(0);    // lowerarm_r
        //weaponParent = weaponParent.GetChild(0);    // hand_r
        //weaponParent = weaponParent.GetChild(2);    // weapon_r

        //shiledParent = spine3.GetChild(1);          // clavicle_l
        //shiledParent = shiledParent.GetChild(1);    // upperarm_l
        //shiledParent = shiledParent.GetChild(0);    // lowerarm_l
        //shiledParent = shiledParent.GetChild(0);    // hand_l
        //shiledParent = shiledParent.GetChild(2);    // weapon_l

        shiledParent = FindChildRecursive(transform, "weapon_l");
        weaponParent = FindChildRecursive(transform, "weapon_r");

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        inputController = GetComponent<PlayerInputController>();

        inputController.onMove += OnMoveInput;
        inputController.onMoveModeChange += OnMoveModeChageInput;
        inputController.onAttack += OnAttackInput;
    }

    private void Update()
    {
        characterController.Move(Time.deltaTime * currentSpeed * inputDirection);   // �� �� ����
        //characterController.SimpleMove(currentSpeed * inputDirection);            // �� �� �ڵ�

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);  // ��ǥ ȸ������ ����
    }

    private void OnMoveInput(Vector2 input, bool isPress)
    {
        inputDirection.x = input.x;     // �Է� ���� ����
        inputDirection.y = 0;
        inputDirection.z = input.y;

        if (isPress)
        {
            // ������ ��Ȳ(�Է��� ������ ��Ȳ)

            // �Է� ���� ȸ�� ��Ű��
            Quaternion camY = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0); // ī�޶��� yȸ���� ���� ����
            inputDirection = camY * inputDirection;     // �Է� ������ ī�޶��� yȸ���� ���� ������ ȸ�� ��Ű��
            targetRotation = Quaternion.LookRotation(inputDirection);   // ��ǥ ȸ�� ����

            // �̵� ��� ����
            MoveSpeedChange(CurrentMoveMode);
        }
        else
        {
            // �Է��� ���� ��Ȳ
            currentSpeed = 0.0f;    // ���� ��Ű��
            animator.SetFloat(Speed_Hash, AnimatorStopSpeed);
        }
    }

    private void OnMoveModeChageInput()
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

    private void OnAttackInput()
    {
        animator.SetTrigger(Attack_Hash);
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

    public void ShowWeaponAndShield(bool isShow = true)
    {
        weaponParent.gameObject.SetActive(isShow);
        shiledParent.gameObject.SetActive(isShow);
    }


// ��������� �ڽ��� �˻��ϴ� �Լ�, ����� �׸� ��ġ ã��
    Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }

            Transform found = FindChildRecursive(child, name);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }
}
