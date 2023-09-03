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

        // 애니메이션 클립의 이름과 비교하여 동일한지 확인
        if (stateInfo.IsName(animationName))
        {
            // 특정 애니메이션이 재생 중인 경우
            return true;
        }

        // 특정 애니메이션이 재생 중이 아닌 경우
        return false;
    }

    
}
