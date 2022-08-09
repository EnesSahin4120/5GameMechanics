using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, _turnSpeed * Time.deltaTime, 0);
    }
}
