using UnityEngine;

public class InteractableBlock : MonoBehaviour, IInteractableBlock
{
    [SerializeField] private float _reactionFactor;

    public void PushObject(Rigidbody rigidBody)
    {
        var positionController = rigidBody.GetComponent<PositionController>();

        Vector3 forceDir = -rigidBody.velocity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(_reactionFactor * forceDir, ForceMode.Impulse);

        positionController.Recuperate();
    }
}
