using UnityEngine;

public class ZombieBaseFSM : StateMachineBehaviour
{
	public GameObject zombie;
	public GameObject target;
	public Rigidbody rb;
	public Animator zombieAnimator;

	private float _speed;
	public float Speed
    {
        get
        {
			return _speed;
        }
        set
        {
			_speed = value;
        }
    }
	private float _rotSpeed;
	public float RotSpeed
    {
        get
        {
			return _rotSpeed;
        }
        set
        {
			_rotSpeed = value;
        }
    }

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		zombie = animator.gameObject;
		Zombie_Info zombie_Info = zombie.GetComponent<Zombie_Info>();
		_speed = zombie_Info.zombieSetting.MoveSpeed;
		_rotSpeed = zombie_Info.zombieSetting.TurnSpeed;

		rb = zombie.GetComponent<Rigidbody>();
		target = zombie_Info.player;
		zombieAnimator = zombie_Info.zombieAnimator;
	}
}
