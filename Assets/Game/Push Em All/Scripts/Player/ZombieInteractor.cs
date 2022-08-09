using UnityEngine;

public class ZombieInteractor : MonoBehaviour, IZombieInteractor<InteractableZombie>
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out InteractableZombie interactableZombie))
        {
            Interact_with_Zombie(interactableZombie, _rb);
        }
    }

    public void Interact_with_Zombie(InteractableZombie interactableZombie, Rigidbody rigidbody)
    {
        interactableZombie.PushPlayer(rigidbody);
    }
}
