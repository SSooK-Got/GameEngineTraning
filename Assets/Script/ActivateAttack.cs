using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAttack : MonoBehaviour
{
    

    public GameObject Target;
    public string targetAnimation = "MeeleeAttack_OneHanded";
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        bool isAttacking = IsAnimationPlaying(targetAnimation);
        if (isAttacking)
        {
            Target.SetActive(true);
            
        }
        else
           Target.SetActive(false);
          

    }

    private bool IsAnimationPlaying(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // �ִϸ��̼� Ŭ���� �̸��� ���Ͽ� �������� Ȯ��
        if (stateInfo.IsName(animationName))
        {
            // Ư�� �ִϸ��̼��� ��� ���� ���
            return true;
        }

        // Ư�� �ִϸ��̼��� ��� ���� �ƴ� ���
        return false;
    }

    
}
