using UnityEngine;
using System;

public class Zombie_Info : MonoBehaviour
{
    public GameObject player;
    public Animator zombieAnimator;

    private Animator _fsmAnimator;
    private bool _isDead;

    public event Action onDeath;

    public ZombieSetting zombieSetting;

    private void Awake()
    {
        _fsmAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        DistanceToTargetControl();
        FallingControl();
    }

    private void DistanceToTargetControl()  
    {
        _fsmAnimator.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
    }

    private void FallingControl()
    {
        if (transform.position.y < -0.03f && !_isDead)
            Death();
    }

    private void Death()
    {
        _fsmAnimator.SetBool("isFalling", true);
        _isDead = true;

        if (onDeath != null)
            onDeath();
    }
}
