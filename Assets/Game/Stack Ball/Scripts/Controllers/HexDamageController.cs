using UnityEngine;
using System.Collections;

public class HexDamageController : MonoBehaviour
{
    private float _destroyDelayTime = 1f;
    private float _damageFactor = 350f;
    private float _torqueFactor = 30f;

    private DamagableHexPart[] _damagableHexParts;
    private Rigidbody[] _rigidbodies;
    private MeshRenderer[] _meshRenderers;

    private void OnEnable()
    {
        GetComponentInfo();
        foreach (var current in _damagableHexParts)
            current.onDamageCall += HexDamage;
    }

    private void OnDisable()
    {
        foreach (var current in _damagableHexParts)
            current.onDamageCall -= HexDamage;
    }

    private void GetComponentInfo()
    {
        _damagableHexParts = GetComponentsInChildren<DamagableHexPart>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void HexDamage()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
            float posX = _meshRenderers[i].bounds.center.x;
            float centerPosX = transform.position.x;
            Vector3 forceDir = (centerPosX - posX < 0) ? Vector3.right : Vector3.left;
            _rigidbodies[i].AddForceAtPosition((forceDir * _damageFactor + Vector3.up), transform.position);
            _rigidbodies[i].AddTorque(Vector3.left * _torqueFactor);
            _rigidbodies[i].velocity = Vector3.down;
        }
        StartCoroutine(DestroyHex());
    }

    private IEnumerator DestroyHex()
    {
        yield return new WaitForSeconds(_destroyDelayTime);
        gameObject.SetActive(false);
    }
}
