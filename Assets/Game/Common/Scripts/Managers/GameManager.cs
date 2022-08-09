using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action onEndGame;

    private void Awake()
    {
        Instance = this;
    }

    public void EndGame()
    {
        if (onEndGame != null)
            onEndGame();
    }
}
