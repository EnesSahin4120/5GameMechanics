using UnityEngine;
using System.Collections;

public class StackController : MonoBehaviour
{
    [Header("Start Info")]
    [SerializeField] private RectangleMovement _rootRectangle;
    [SerializeField] private RectangleMovement _startRectangle;
    private float _startPosZ;
    private float _startPosX;

    [Header("Spawn Info")]
    [SerializeField] private RectangleMovement _movingRectanglePrefab; 
    [SerializeField] private GameObject _fallingRectanglePrefab;

    private RectangleMovement _currentRectangle;
    private RectangleMovement _previousRectangle;
    private bool _canControlling = true;

    private void OnEnable()
    {
        InputInfo.onPressed += StopCurrentRectangle;
        InputInfo.onPressed += CreateNewRectangle;
    }

    private void OnDisable()
    {
        InputInfo.onPressed -= StopCurrentRectangle;
        InputInfo.onPressed -= CreateNewRectangle;
    }

    private void Start()
    {
        GetStartInfo();
    }

    private void GetStartInfo()
    {
        _startPosX = _startRectangle.transform.position.x;
        _startPosZ = _startRectangle.transform.position.z;
        _previousRectangle = _rootRectangle;
        _currentRectangle = _startRectangle;
    }

    private void StopCurrentRectangle()
    {
        _currentRectangle.moveSpeed = 0f;

        float diffPosZ = _currentRectangle.transform.position.z - _previousRectangle.transform.position.z;
        if (Mathf.Abs(diffPosZ) >= _previousRectangle.transform.localScale.z)
        {
            _canControlling = false;
            GameManager.Instance.EndGame();
            return;
        }

        float direction = diffPosZ > 0 ? 1 : -1;
        SeparateRectangles(diffPosZ, direction);
    }

    private void SeparateRectangles(float diffPosZ, float direction)
    {
        float newSizeZ = _previousRectangle.transform.localScale.z - Mathf.Abs(diffPosZ);
        float fallingSizeZ = _currentRectangle.transform.localScale.z - newSizeZ;

        float newPosZ = _previousRectangle.transform.position.z + (diffPosZ / 2f);
        _currentRectangle.transform.position = new Vector3(_currentRectangle.transform.position.x,
                                                           _currentRectangle.transform.position.y,
                                                           newPosZ);
        _currentRectangle.transform.localScale = new Vector3(_currentRectangle.transform.localScale.x,
                                                             _currentRectangle.transform.localScale.y,
                                                             newSizeZ);

        float cubeEdge = _currentRectangle.transform.position.z + (newSizeZ / 2f * direction); 
        float fallingPosZ = cubeEdge + (fallingSizeZ / 2f * direction);

        CreateFallingRectangle(fallingPosZ, fallingSizeZ);
    }

    private void CreateFallingRectangle(float fallingPosZ, float fallingSizeZ) 
    {
        Vector3 fallingPos = new Vector3(_currentRectangle.transform.position.x,
                                         _currentRectangle.transform.position.y, 
                                         fallingPosZ);
        Vector3 fallingScale = new Vector3(_currentRectangle.transform.localScale.x,
                                           _currentRectangle.transform.localScale.y,
                                           fallingSizeZ);

        GameObject fallingRectangle = ObjectPooler.Instance.SpawnToPool("FallingRectangle", fallingPos, Quaternion.identity, null);
        fallingRectangle.transform.localScale = fallingScale;
        StartCoroutine(DestroyRectangle(fallingRectangle.gameObject));
    }

    private void CreateNewRectangle()
    {
        if (_canControlling)
        {
            _previousRectangle = _currentRectangle;
            RectangleMovement movingRectangle = ObjectPooler.Instance.SpawnToPool("Rectangle", transform.position, Quaternion.identity, null).GetComponent<RectangleMovement>();
            movingRectangle.transform.position = new Vector3(_startPosX,
                                                             _previousRectangle.transform.position.y + movingRectangle.transform.localScale.y,
                                                             _startPosZ);
            _currentRectangle = movingRectangle;
        }
    }

    private IEnumerator DestroyRectangle(GameObject rectangle)
    {
        yield return new WaitForSeconds(1f);
        rectangle.SetActive(false);
    }
}
