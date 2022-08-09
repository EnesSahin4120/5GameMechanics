using UnityEngine;

public class FinishInteractor : MonoBehaviour, IFinishInteractor
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out IInteractableFinish interactableFinish))
        {
            Interact_with_FinishLine(interactableFinish);
        }
    }

    public void Interact_with_FinishLine(IInteractableFinish interactableFinish) 
    {
        interactableFinish.Interact_with_Player();
    }
}
