using UnityEngine;

public class ZombieFalling : ZombieBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rb.velocity = new Vector3(0, -2, 0);
    }
}
