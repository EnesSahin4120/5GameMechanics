using UnityEngine;

public class ZombieAttack : ZombieBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        zombieAnimator.SetTrigger("Walk");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 lookDir = Geometry.LookDirection(zombie.transform, target.transform);
        zombie.transform.Slerp(Quaternion.LookRotation(lookDir), Time.deltaTime * RotSpeed);
        rb.velocity = zombie.transform.forward * Speed;
    }
}
