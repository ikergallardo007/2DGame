using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private Slider _energySlider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Jetpack _jetpack;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        _energySlider.value = 100 * _jetpack.Energy / _jetpack.MaxEnergy;
        _text.text = ((int)_jetpack.transform.position.y).ToString();
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
