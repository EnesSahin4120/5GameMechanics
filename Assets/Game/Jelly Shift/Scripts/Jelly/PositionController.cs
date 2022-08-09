using UnityEngine;
using System.Collections;

public class PositionController : MonoBehaviour
{
    [SerializeField] private Transform _jelly;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _recuperateTime;

    private float _jellyPosY;

    private MeshRenderer _meshRenderer;
    private Rigidbody _rb;

    private void Awake()
    {
        _meshRenderer = _jelly.GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameManager.onEndGame += Stop;
    }

    private void OnDisable()
    {
        GameManager.onEndGame -= Stop;
    }

    private void Start()
    {
        _rb.velocity = new Vector3(0, 0, _moveSpeed);
    }

    private void Update()
    {
        SetJellyPosition();
    }

    private void Stop()
    {
        _rb.velocity = Vector3.zero;
    }

    private void SetJellyPosition()
    {
        _jellyPosY = _jelly.position.y - BottomPosY();
        _jelly.position = new Vector3(_jelly.position.x, _jellyPosY, _jelly.position.z);
    }

    private float BottomPosY()
    {
        return _meshRenderer.bounds.min.y;
    }

    public void Recuperate()
    {
        StopAllCoroutines();
        StartCoroutine(VelocityModifyingProcess(_recuperateTime));
    }

    private IEnumerator VelocityModifyingProcess(float completeInSeconds)
    {
        yield return new WaitForSeconds(0.05f);
        float startVelocityZ = _rb.velocity.z;
        float diffVelocityZ = _moveSpeed - startVelocityZ;
        float velocityZ;

        float t = 0f;
        while (t < completeInSeconds)
        {
            t += Time.deltaTime;
            velocityZ = diffVelocityZ * Mathf.Pow(2, 10 * (t / completeInSeconds - 1)) + startVelocityZ;
            _rb.velocity = new Vector3(0, 0, velocityZ);
            yield return null;
        }
        yield break;
    }
}
