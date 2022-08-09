using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _currentSceneIndex
    {
        get
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }

    private void OnEnable()
    {
        UIManager.onClickNext += PlayNewLevel;
        UIManager.onClickRestart += RestartLevel;
    }

    private void OnDisable()
    {
        UIManager.onClickNext -= PlayNewLevel;
        UIManager.onClickRestart -= RestartLevel;
    }

    private void PlayNewLevel()
    {
        if (_currentSceneIndex == 4)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }
}
