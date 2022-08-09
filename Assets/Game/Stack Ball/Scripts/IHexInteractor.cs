public interface IHexInteractor
{
    public void Interact_with_Hex(IInteractableHexPart interactableHexPart);
}

public interface IInteractableHexPart
{
    public void Interact_with_Ball();
}
