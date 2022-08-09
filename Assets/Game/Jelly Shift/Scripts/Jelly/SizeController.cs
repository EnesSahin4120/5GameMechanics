using UnityEngine;

public class SizeController : MonoBehaviour
{
    [SerializeField] private InputInfo _inputInfo;

    [Range(0, 0.005f)]
    [SerializeField] private float _sizeChangeFactor;
    private float _minScale = 0.8f;
    private float _maxScale = 5f;
    private float _area;

    private float _scaleX;
    private float _scaleY;
    private float _clickScaleY;
    private bool _isModifying;


    private void OnEnable()
    {
        InputInfo.onPressed += StartModifying;
        InputInfo.onPressedUp += StopModifying;
    }

    private void OnDisable()
    {
        InputInfo.onPressed -= StartModifying;
        InputInfo.onPressedUp -= StopModifying;
    }

    private void Start()
    {
        GetOriginParameters();
    }

    private void Update()
    {
        SetScale();
    }

    private void GetOriginParameters()
    {
        _scaleX = transform.localScale.x;
        _scaleY = transform.localScale.y;
        _area = _scaleX * _scaleY;
    }

    private void SetScale()
    {
        if (_isModifying)
            _scaleY = _clickScaleY + _inputInfo.DiffMousePos.y * _sizeChangeFactor;

        _scaleY = Mathf.Clamp(_scaleY, _minScale, _maxScale);
        _scaleX = _area / _scaleY;
        transform.localScale = new Vector3(_scaleX, _scaleY, transform.localScale.z);
    }

    private void StartModifying()
    {
        _isModifying = true;
        _clickScaleY = _scaleY;
    }

    private void StopModifying()
    {
        _isModifying = false;
    }
}
