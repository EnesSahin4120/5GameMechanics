using UnityEngine;

public class WallInteractor : MonoBehaviour, IWallInteractor<InteractableWall>
{
    [SerializeField] private InputInfo _inputInfo;
    [SerializeField] private float _reachInMeters;

    private void Update()
    {
        if (_inputInfo.IsPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _reachInMeters)){
                if (hit.collider.TryGetComponent(out InteractableWall interactableWall)){
                    Interact_with_Wall(interactableWall, hit.point);
                }
            }
        }
    }

    public void Interact_with_Wall(InteractableWall interactableWall, Vector3 deformCenter)
    {
        interactableWall.Deform(deformCenter);
    }
}
