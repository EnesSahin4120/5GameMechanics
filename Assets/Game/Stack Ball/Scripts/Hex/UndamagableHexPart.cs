using UnityEngine;

public class UndamagableHexPart : InteractableHexPart
{
    public override void Interact_with_Ball()
    {
        GameManager.Instance.EndGame();
    }
}
