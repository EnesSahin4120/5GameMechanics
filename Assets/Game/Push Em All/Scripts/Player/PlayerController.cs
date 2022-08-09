using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputInfo _inputInfo;

    private PlayerRotate _playerRotate;
    private PlayerMovement _playerMovement;

    private bool _canMove = true;

    private void Awake()
    {
        GetComponentInfo();
    }

    private void OnEnable()
    {
        GameManager.onEndGame += StopAction;
    }

    private void OnDisable()
    {
        GameManager.onEndGame -= StopAction;
    }

    private void GetComponentInfo()
    {
        _playerRotate = GetComponent<PlayerRotate>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_inputInfo.IsPressed && _canMove){
            if (Vector3.SqrMagnitude(_inputInfo.DiffMousePos) > 0){
                Vector3 dir = _inputInfo.DiffMousePos.normalized;
                _playerRotate.Turn(dir);
                _playerMovement.Move(dir);
            }
        }
    }

    private void StopAction()
    {
        _canMove = false;
    }
}
