using UnityEngine;

public static class TransformExtensions
{
    public static void Slerp(this Transform transform, Quaternion lookQuaternion, float speed)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, lookQuaternion, speed);
    }
}
