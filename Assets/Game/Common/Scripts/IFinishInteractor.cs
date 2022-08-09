public interface IFinishInteractor 
{
    public void Interact_with_FinishLine(IInteractableFinish interactableFinish);
}

public interface IInteractableFinish
{
    public void Interact_with_Player();
}
