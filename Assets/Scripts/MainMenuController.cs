using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuController : MonoBehaviour
{
    #region Fields
    [SerializeField] Button _startGamenButton;
    [SerializeField] Button _exitGamenButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] GameObject _menuPanel;
    [SerializeField] GameObject _uiSettingsPanel;
    #endregion

    #region Unity Callbacks
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _startGamenButton.onClick.AddListener(StartGame);
        _exitGamenButton.onClick.AddListener(ExitGame);
        _settingsButton.onClick.AddListener(OpenSettings);
    }
    #endregion

    #region Private Methods
    private void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    private void OpenSettings()
    {
        _menuPanel.SetActive(false);
        _settingsButton.gameObject.SetActive(false);
        _uiSettingsPanel.SetActive(true);
    }

    #endregion
}