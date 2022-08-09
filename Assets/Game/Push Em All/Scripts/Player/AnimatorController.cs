using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private InputInfo _inputInfo;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetAnimationSpeed();
    }

    private void SetAnimationSpeed()
    {
        _animator.speed = Vector3.SqrMagnitude(_inputInfo.DiffMousePos) > 0 ? 1.5f : 0.3f;
    }
}
