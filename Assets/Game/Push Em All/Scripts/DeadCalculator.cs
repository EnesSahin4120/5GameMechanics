using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCalculator : MonoBehaviour
{
    private Zombie_Info[] _zombie_Infos;
    private int _deadCount = 0;

    private void Awake()
    {
        _zombie_Infos = FindObjectsOfType<Zombie_Info>();
    }

    private void OnEnable()
    {
        foreach(var current in _zombie_Infos)
            current.onDeath += ControlDeads;
    }

    private void OnDisable()
    {
        foreach (var current in _zombie_Infos)
            current.onDeath -= ControlDeads;
    }

    private void ControlDeads()
    {
        _deadCount++;
        if (_deadCount == _zombie_Infos.Length)
            GameManager.Instance.EndGame();
    }
}
