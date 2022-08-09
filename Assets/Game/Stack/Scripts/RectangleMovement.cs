using UnityEngine;

public class RectangleMovement : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
