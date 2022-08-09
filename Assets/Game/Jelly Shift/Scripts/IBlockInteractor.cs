using UnityEngine;

public interface IBlockInteractor<T> where T : IInteractableBlock
{
    public void Interact_with_Block(T interactableBlock, Rigidbody rigidbody);
}

public interface IInteractableBlock
{
    public void PushObject(Rigidbody rigidbody);
}
