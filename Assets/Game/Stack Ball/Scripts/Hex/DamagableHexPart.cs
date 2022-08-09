using System;
using UnityEngine;

public class DamagableHexPart : InteractableHexPart
{
    private Collider _coll;

    public event Action onDamageCall;

    private void OnEnable()
    {
        _coll = GetComponent<Collider>();
    }

    public override void Interact_with_Ball()
    {
        _coll.enabled = false;
        if (onDamageCall != null)
            onDamageCall();
    }
}
