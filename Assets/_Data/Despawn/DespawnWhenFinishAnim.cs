using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWhenFinishAnim : Despawn
{
    [SerializeField] protected Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.parent.Find("Model").GetComponent<Animator>();
        Debug.Log($"{transform.name}: LoadAnimator", gameObject);
    }

    protected override bool CanDespawn()
    {
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return animatorStateInfo.length < animatorStateInfo.normalizedTime;
    }
}
