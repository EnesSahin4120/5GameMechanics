using UnityEngine;

public interface IZombieInteractor <T> where T : IInteractableZombie
{
    public void Interact_with_Zombie(T interactableZombie, Rigidbody rigidbody);
}

public interface IInteractableZombie
{
    public void PushPlayer(Rigidbody rigidbody);
}
