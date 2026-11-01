using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UISettings : MonoBehaviour
{
    #region Fields
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _closeButton;
    [SerializeField] GameObject _titleObject;
    [SerializeField] GameObject _menuPanel;
    [SerializeField] TMP_Dropdown _qualityDrop;
    [SerializeField] Toggle _vsyncToggle;
    [SerializeField] Toggle _fullScreenToggle;
    [SerializeField] Toggle _noShadowToggle;
    [SerializeField] Toggle _softShadowToggle;
    [SerializeField] Toggle _hardShadowToggle;
    [SerializeField] Slider _particlesResolutionSlider;

    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _closeButton.onClick.AddListener(CloseSettings);
        _qualityDrop.onValueChanged.AddListener(SetQuality);
        _vsyncToggle.onValueChanged.AddListener(SetVSync);
        _fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
        _particlesResolutionSlider.onValueChanged.AddListener(SetParticleResolution);
        _noShadowToggle.onValueChanged.AddListener(SetNoShadows);
        _softShadowToggle.onValueChanged.AddListener(SetSoftShadows);
        _hardShadowToggle.onValueChanged.AddListener(SetHardShadows);
        InitializeDropDownQuality();
    }

    #region Private Methods
    private void InitializeDropDownQuality()
    {
        _qualityDrop.ClearOptions();

        List<string> options = new List<string>(QualitySettings.names);
        _qualityDrop.AddOptions(options);

        // Configura el nivel de calidad actual como la opción seleccionada
        _qualityDrop.value = QualitySettings.GetQualityLevel();
        _qualityDrop.RefreshShownValue();
    }
    private void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }
    private void SetVSync(bool stateOn)
    {
        if (stateOn)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }
    private void SetFullScreen(bool state)
    {
        Screen.fullScreen = state;
    }
    private void SetParticleResolution(float level)
    {
        QualitySettings.particleRaycastBudget = (int)level;
    }
    private void SetNoShadows(bool stateOn)
    {
        if (stateOn)
            QualitySettings.shadows = ShadowQuality.Disable;
    }
    private void SetSoftShadows(bool stateOn)
    {
        if (stateOn)
            QualitySettings.shadows = ShadowQuality.All;
    }
    private void SetHardShadows(bool stateOn)
    {
        if (stateOn)
            QualitySettings.shadows = ShadowQuality.HardOnly;
    }

    private void CloseSettings()
    {
        gameObject.SetActive(false);
        _titleObject.SetActive(true);
        _menuPanel.SetActive(true);
        _settingsButton.gameObject.SetActive(true);
    }
    #endregion
}
