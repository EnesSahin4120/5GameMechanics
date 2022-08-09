using UnityEngine;

public class InteractableWall : MonoBehaviour, IInteractableWall
{
    [SerializeField] private GameObject _deformPrefab;
    [SerializeField] private float _deformRadius;
    [SerializeField] private float _deformFactor;

    private Wall _wall;

    private void Awake()
    {
        _wall = GetComponent<Wall>();
    }

    public void Deform(Vector3 deformCenter)
    {
        Vector3 worldDeformPos = deformCenter;
        deformCenter = transform.InverseTransformPoint(deformCenter);
        for (int i = 0; i < _wall.Vertices.Count; i++)
        {
            Vector3 currentVertex = _wall.Vertices[i];
            float distance = (currentVertex - deformCenter).sqrMagnitude;
            if (distance < _deformRadius)
            {
                GameObject deformObject = ObjectPooler.Instance.SpawnToPool("DeformObject", worldDeformPos + Vector3.forward * 2f, Quaternion.Euler(90, 0, 0), null);
                currentVertex += Vector3.forward * _deformFactor;
                _wall.Vertices[i] = currentVertex;
                _wall.UpdateMesh();
            }
        }
    }
}
