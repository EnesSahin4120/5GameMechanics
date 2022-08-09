using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = _player.position;
    }
}
