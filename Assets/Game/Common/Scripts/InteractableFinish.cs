using UnityEngine;

public class InteractableFinish : MonoBehaviour, IInteractableFinish
{
    public void Interact_with_Player()
    {
        GameManager.Instance.EndGame();
    }
}
