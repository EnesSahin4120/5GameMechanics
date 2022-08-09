using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.EndGame();
        }
    }
}
