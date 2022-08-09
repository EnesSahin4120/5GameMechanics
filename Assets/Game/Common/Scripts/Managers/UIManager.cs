using UnityEngine.UI;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextButton;

    public static event Action onClickRestart;
    public static event Action onClickNext; 

    private void OnEnable()
    {
        GameManager.onEndGame += ShowPlayButtons;
    }

    private void OnDisable()
    {
        GameManager.onEndGame -= ShowPlayButtons;
    }

    private void Start()
    {
        _restartButton.onClick.AddListener(() => ClickRestart());
        _nextButton.onClick.AddListener(() => ClickNext());
        HidePlayButtons();
    }

    private void HidePlayButtons() 
    {
        _restartButton.gameObject.SetActive(false);
        _nextButton.gameObject.SetActive(false);
    }

    private void ShowPlayButtons()
    {
        _restartButton.gameObject.SetActive(true);
        _nextButton.gameObject.SetActive(true);
    }

    private void ClickRestart()
    {
        if (onClickRestart != null)
            onClickRestart();
    }

    private void ClickNext()
    {
        if (onClickNext != null)
            onClickNext();
    }
}
