using UnityEngine;

public class InteractableZombie : MonoBehaviour, IInteractableZombie
{
    private Zombie_Info _zombie_Info;
    private float _pushFactor
    {
        get
        {
            return _zombie_Info.zombieSetting.PushFactor;
        }
    }

    private void Awake()
    {
        _zombie_Info = GetComponent<Zombie_Info>();
    }

    public void PushPlayer(Rigidbody rigidbody)
    {
        Vector3 relativeDir = (transform.position - rigidbody.transform.position).normalized;
        float dotResult = Vector3.Dot(rigidbody.transform.forward, relativeDir);
        if (dotResult <= 0)
        {
            Vector3 forceDir = (rigidbody.transform.position - transform.position).normalized;
            rigidbody.AddForce(forceDir * _pushFactor, ForceMode.Impulse);
        }
    }
}
