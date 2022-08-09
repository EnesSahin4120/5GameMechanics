using UnityEngine;
using System;

public class BlockInteractor : MonoBehaviour, IBlockInteractor<InteractableBlock>
{
    [SerializeField] private Rigidbody _rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out InteractableBlock interactableBlock))
            Interact_with_Block(interactableBlock, _rb);
    }

    public void Interact_with_Block(InteractableBlock interactableBlock, Rigidbody rigidbody)
    {
        interactableBlock.PushObject(rigidbody);
    }
}
