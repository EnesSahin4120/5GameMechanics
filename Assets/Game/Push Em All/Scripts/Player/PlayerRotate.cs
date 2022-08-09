using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;

    public void Turn(Vector2 target)
    {
        Vector3 newRotation = new Vector3(target.x, 0, target.y);
        Quaternion newLookQuaternion = Quaternion.LookRotation(newRotation, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, newLookQuaternion, _turnSpeed * Time.deltaTime);
    }
}
