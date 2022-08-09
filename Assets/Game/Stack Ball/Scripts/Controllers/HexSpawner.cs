using UnityEngine;

public class HexSpawner : MonoBehaviour
{
    [SerializeField] private Transform _rotator;
    [SerializeField] private GameObject[] _hexPrefabs;

    private int _similarHexCount = 10;
    private float _spaceAmount = 0.5f;
    private float _angleY_IncreaseAmount = 6;

    private void Start()  
    {
        SpawnHexes();
    }

    private void SpawnHexes()
    {
        for (int i = 0; i < _hexPrefabs.Length; i++)
        {
            float angleY = 0;
            for (int j = 0; j < _similarHexCount; j++)
            {
                GameObject hex = ObjectPooler.Instance.SpawnToPool("Hex" + i, transform.position, Quaternion.identity, _rotator);

                hex.transform.localPosition = new Vector3(0, - _spaceAmount * (i * _similarHexCount + j), 0);
                hex.transform.localRotation = Quaternion.Euler(0, angleY, 0);

                angleY += _angleY_IncreaseAmount;
            }
        }
    }
}
