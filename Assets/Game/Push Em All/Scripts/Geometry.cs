using UnityEngine;

public class Geometry : MonoBehaviour
{
    static public Vector3 LookDirection(Transform observer, Transform target)
    {
        Vector3 lookAtGoal = new Vector3(target.transform.position.x,
                                 observer.transform.position.y,
                                 target.transform.position.z);

        Vector3 direction = lookAtGoal - observer.transform.position;
        return direction;
    }
}
