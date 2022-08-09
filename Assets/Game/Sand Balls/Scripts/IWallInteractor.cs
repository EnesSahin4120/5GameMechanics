using UnityEngine;

public interface IWallInteractor <T> where T : IInteractableWall
{
    public void Interact_with_Wall(T interactableWall, Vector3 deformCenter);
}

public interface IInteractableWall
{
    public void Deform(Vector3 deformCenter);
}
