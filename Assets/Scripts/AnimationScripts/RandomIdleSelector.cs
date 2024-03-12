using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleSelector : StateMachineBehaviour
{
    readonly int IdleSelect_Hash = Animator.StringToHash("IdleSelect");
    int prevSelect = 0;
    public int test = -1;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 랜덤한 값을 생성하여 IdleSelect에 할당
        animator.SetInteger(IdleSelect_Hash, RandomSelect());
    }

    int RandomSelect()
    {
        int select = 0;

        if(prevSelect == 0)
        {
            float num = Random.value;

            if (num < 0.05f)
            {
                select = 4;
            }
            else if (num < 0.15f)
            {
                select = 3;
            }
            else if (num < 0.3f)
            {
                select = 2;
            }
            else if (num < 0.45f)
            {
                select = 1;
            }
            else
            {
                select = 0;
            }
        }
        if(test != -1)
        {
            select = test;
        }
        
        return select;
    }
}
