using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Vector2 target)
    {
        Vector3 newPos = new Vector3(target.x, 0, target.y);
        transform.position += newPos * _speed * Time.deltaTime;
    }
}
