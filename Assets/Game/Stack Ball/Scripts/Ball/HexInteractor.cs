using UnityEngine;
using System;

public class HexInteractor : MonoBehaviour, IHexInteractor
{
    private BallMovement _ballMovement;

    private void Awake()
    {
        _ballMovement = GetComponent<BallMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_ballMovement.IsSmashMoving)
        {
            _ballMovement.Jump();
            return;
        }

        if (collision.transform.TryGetComponent(out IInteractableHexPart interactableHexPart))
        {
            Interact_with_Hex(interactableHexPart);
        }
    }

    public void Interact_with_Hex(IInteractableHexPart interactableHexPart)
    {
        interactableHexPart.Interact_with_Ball();
    }
}
