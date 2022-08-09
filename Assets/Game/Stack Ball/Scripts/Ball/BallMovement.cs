using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _downwardSpeed;
    [SerializeField] private float _maxJumpVelocity;
    [SerializeField] private float _jumpSpeed;

    private bool _isSmashMoving;
    public bool IsSmashMoving
    {
        get
        {
            return _isSmashMoving;
        }
        set
        {
            _isSmashMoving = value;
        }
    }

    private Rigidbody _rb;
    private bool _canMove = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputInfo.onPressed += SetSmashMovement;
        InputInfo.onPressedUp += SetStoppingSmashMovement;
        GameManager.onEndGame += StopAction;
    }

    private void OnDisable()
    {
        InputInfo.onPressed -= SetSmashMovement;
        InputInfo.onPressedUp -= SetStoppingSmashMovement;
        GameManager.onEndGame -= StopAction;
    }

    private void FixedUpdate()
    {
        if (_isSmashMoving)
            _rb.velocity = new Vector3(0, -_downwardSpeed * Time.fixedDeltaTime, 0);

        if (_rb.velocity.y > _maxJumpVelocity)
            _rb.velocity = new Vector3(0, _maxJumpVelocity, 0);
    }

    public void Jump()
    {
        _rb.velocity = new Vector3(0, _jumpSpeed, 0);
    }

    private void SetSmashMovement()
    {
        if(_canMove)
            _isSmashMoving = true;
    }

    private void SetStoppingSmashMovement()
    {
        _isSmashMoving = false;
    }

    private void StopAction()
    {
        SetStoppingSmashMovement();
        _canMove = false;
    }
}
